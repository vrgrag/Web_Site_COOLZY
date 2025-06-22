import React, { useEffect, useState } from "react";
import { getProducts } from "../../api";
import { Link } from "react-router-dom";
import Filters from "../../Components/Filters/Filters";
import "./CategoryPage.css";

const categoryMap = {
  "Смартфоны": 1,
  "Ноутбуки": 2,
  "Планшеты": 3,
  "Телевизоры": 4,
  "Колонки": 5
};

const CategoryPage = ({ category }) => {
  const [products, setProducts] = useState([]);
  const [filters, setFilters] = useState({
    ram: "",
    storage: "",
    minPrice: "",
    maxPrice: ""
  });

  const handleFilterChange = (name, value) => {
    if (name === "reset") {
      setFilters({ ram: "", storage: "", minPrice: "", maxPrice: "" });
    } else {
      setFilters(prev => ({ ...prev, [name]: value }));
    }
  };

  useEffect(() => {
    getProducts().then((allProducts) => {
      const categoryId = categoryMap[category];
      const filtered = allProducts.filter(p => {
        const price = p.price;
        const min = Number(filters.minPrice) || 0;
        const max = Number(filters.maxPrice) || Infinity;

        return (
          p.categoryId === categoryId &&
          (!filters.ram || p.description.toLowerCase().includes(filters.ram.toLowerCase())) &&
          (!filters.storage || p.description.toLowerCase().includes(filters.storage.toLowerCase())) &&
          price >= min && price <= max
        );
      });
      setProducts(filtered);
    });
  }, [category, filters]);

  return (
    <div className="category-page">
      <div className="filters-panel">
        <Filters
          category={category}
          filters={filters}
          onFilterChange={handleFilterChange}
        />
      </div>

      <div className="category-catalog">
        <h1>Каталог {category.toLowerCase()}</h1>
        <div className="product-grid">
          {products.map((product) => (
            <Link
              to={`/products/${product.productId}`}
              key={product.productId}
              className="product-card"
            >
              <div className="product-image-container">
                <img
                  src={product.images[0]?.imageUrl || "https://via.placeholder.com/300"}
                  alt={product.name}
                />
                {product.oldPrice && product.oldPrice > product.price && (
                  <div className="discount-badge">
                    -{Math.round(((product.oldPrice - product.price) / product.oldPrice) * 100)}%
                  </div>
                )}
                {product.quantityInStock > 0 && (
                  <div className="availability-badge">В наличии</div>
                )}
              </div>
              <div className="product-content">
                <h3>{product.name}</h3>
                {product.oldPrice && (
                  <p className="old-price">{product.oldPrice.toLocaleString()} BYN</p>
                )}
                <p className="new-price">{product.price.toLocaleString()} </p>
                <p className="description">{product.description.split(",")[0]}</p>
                <button
                  className="add-to-cart-btn"
                  onClick={(e) => {
                    e.preventDefault();
                    console.log(`Добавлено в корзину: ${product.productId}`);
                  }}
                >
                  В корзину
                </button>
              </div>
            </Link>
          ))}
        </div>
      </div>
    </div>
  );
};

export default CategoryPage;
