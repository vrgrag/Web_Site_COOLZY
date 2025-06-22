import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import "./ComparePage.css";

const ComparePage = () => {
  const [products, setProducts] = useState([]);
  const [groupedSpecs, setGroupedSpecs] = useState({});
  const navigate = useNavigate();

  useEffect(() => {
    let compareIds = JSON.parse(localStorage.getItem("compare")) || [];
    compareIds = compareIds.filter(id => id !== null && id !== "null");

    Promise.all(compareIds.map(async (id) => {
      try {
        const [productRes, specRes] = await Promise.all([
          fetch(`http://localhost:5085/api/products/${id}`),
          fetch(`http://localhost:5085/api/specifications/${id}`)
        ]);
        if (!productRes.ok || !specRes.ok) throw new Error("Ошибка загрузки");

        const product = await productRes.json();
        const spec = await specRes.json();
        return { product, spec };
      } catch (err) {
        console.error(`Ошибка загрузки данных для товара ${id}:`, err);
        return null;
      }
    }))
    .then(data => {
      const valid = data.filter(p => p && p.product);
      setProducts(valid.map(p => p.product));

      const grouped = {};
      valid.forEach(({ product, spec }) => {
        spec.forEach(({ groupName, attributeName, attributeValue }) => {
          if (!grouped[groupName]) grouped[groupName] = {};
          if (!grouped[groupName][attributeName]) grouped[groupName][attributeName] = {};
          grouped[groupName][attributeName][product.productId] = attributeValue;
        });
      });
      setGroupedSpecs(grouped);
    });
  }, []);

  return (
    <div className="compare-page">
      <h2>Сравнение товаров</h2>

      {products.length < 2 ? (
        <p>Добавьте минимум 2 товара для сравнения</p>
      ) : (
        <div className="compare-table-wrapper">
          <table className="compare-table">
            <thead>
              <tr>
                <th>Товар</th>
                {products.map(product => (
                  <th key={product.productId}>
                    <img
                      src={product.images?.[0]?.imageUrl || "/default.jpg"}
                      alt={product.model}
                      onError={(e) => e.target.src = "/default.jpg"}
                      style={{ width: "100px", height: "100px", objectFit: "cover" }}
                    />
                    <div>{product.model}</div>
                    <div>{product.newPrice} BYN</div>
                  </th>
                ))}
              </tr>
            </thead>
            <tbody>
              <tr><td>RAM</td>{products.map(p => <td key={p.productId}>{p.ram || "—"}</td>)}</tr>
              <tr><td>Storage</td>{products.map(p => <td key={p.productId}>{p.storage || "—"}</td>)}</tr>
              <tr><td>Бренд</td>{products.map(p => <td key={p.productId}>{p.brand || "—"}</td>)}</tr>

              {Object.entries(groupedSpecs).map(([groupName, attributes]) => (
                <React.Fragment key={groupName}>
                  <tr className="group-row">
                    <td colSpan={products.length + 1}>{groupName}</td>
                  </tr>
                  {Object.entries(attributes).map(([attrName, values]) => (
                    <tr key={attrName}>
                      <td>{attrName}</td>
                      {products.map(p => (
                        <td key={p.productId}>
                          {values[p.productId] || "—"}
                        </td>
                      ))}
                    </tr>
                  ))}
                </React.Fragment>
              ))}
            </tbody>
          </table>
        </div>
      )}

      <div className="compare-actions">
        <button onClick={() => navigate("/")}>Назад</button>
        <button
          style={{ backgroundColor: "#dc3545" }}
          onClick={() => {
            localStorage.removeItem("compare");
            window.location.reload();
          }}
        >
          Очистить сравнение
        </button>
      </div>
    </div>
  );
};

export default ComparePage;
