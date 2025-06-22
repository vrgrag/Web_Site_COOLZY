import { useEffect, useState } from "react";
import axios from "axios";

export default function ProductManager() {
  const [products, setProducts] = useState([]);
  const [form, setForm] = useState({
    model: "",
    brand: "",
    newPrice: "",
    availability: "В наличии",
    image: null
  });
  const [editId, setEditId] = useState(null);

  useEffect(() => {
    load();
  }, []);

  const load = () => {
    axios.get("http://localhost:5085/api/admin/products")
      .then(res => {
        setProducts(res.data);
      });
  };

  const handleChange = (e) => {
    const { name, value, files } = e.target;
    if (name === "image") {
      setForm({ ...form, image: files[0] });
    } else {
      setForm({ ...form, [name]: value });
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    const data = new FormData();
    data.append("model", form.model);
    data.append("brand", form.brand);
    data.append("newPrice", form.newPrice);
    data.append("availability", form.availability);
    data.append("image", form.image);

    try {
      if (editId) {
        await axios.put(`http://localhost:5085/api/admin/products/${editId}`, data);
        alert("Товар обновлён");
      } else {
        await axios.post("http://localhost:5085/api/admin/products/add", data);
        alert("Товар добавлен");
      }
      setForm({ model: "", brand: "", newPrice: "", availability: "В наличии", image: null });
      setEditId(null);
      load();
    } catch (err) {
      console.error(err);
      alert("Ошибка при сохранении");
    }
  };

  const handleDelete = async (id) => {
    if (!window.confirm("Удалить товар?")) return;
    await axios.delete(`http://localhost:5085/api/admin/products/${id}`);
    load();
  };

  return (
    <div style={{ maxWidth: "1000px", margin: "0 auto", padding: "30px" }}>
      <h2 style={{ marginBottom: 20, fontSize: "24px", fontWeight: "bold" }}>
        {editId ? "✏️ Редактировать товар" : "📦 Добавить новый товар"}
      </h2>

      <form onSubmit={handleSubmit} style={{ display: "grid", gap: 12, marginBottom: 40 }}>
        <input name="model" value={form.model} onChange={handleChange} placeholder="Модель" required />
        <input name="brand" value={form.brand} onChange={handleChange} placeholder="Бренд" required />
        <input name="newPrice" type="number" value={form.newPrice} onChange={handleChange} placeholder="Цена" required />
        <select name="availability" value={form.availability} onChange={handleChange}>
          <option value="В наличии">В наличии</option>
          <option value="Нет в наличии">Нет в наличии</option>
        </select>
        <input type="file" name="image" onChange={handleChange} accept="image/*" required={!editId} />
        <button type="submit" style={{
          padding: "10px 20px",
          backgroundColor: "#2563eb",
          color: "#fff",
          border: "none",
          borderRadius: "6px"
        }}>{editId ? "Сохранить изменения" : "Добавить товар"}</button>
      </form>

      <table style={{ width: "100%", borderCollapse: "collapse", fontSize: "14px" }}>
        <thead>
          <tr style={{ backgroundColor: "#f3f4f6" }}>
            <th style={th}>Фото</th>
            <th style={th}>Модель</th>
            <th style={th}>Бренд</th>
            <th style={th}>Цена</th>
            <th style={th}>Наличие</th>
            <th style={th}>Количество</th>
            <th style={th}>Действия</th>
          </tr>
        </thead>
        <tbody>
          {products.map(p => (
            <tr key={p.productId}>
              <td style={td}>
                <img src={p.images?.[0]?.imageUrl || "/img/placeholder.png"} width="60" height="60" style={{ borderRadius: "8px" }} alt="Товар" />
              </td>
              <td style={td}>{p.model}</td>
              <td style={td}>{p.brand}</td>
              <td style={td}>{p.newPrice} руб.</td>
              <td style={td}>{p.availability}</td>
              <td style={td}>
                <input
                  type="number"
                  value={p.quantity ?? 0}
                  style={{ width: "60px", padding: "4px" }}
                  onChange={(e) => {
                    const value = parseInt(e.target.value);
                    setProducts(prev =>
                      prev.map(pr => pr.productId === p.productId ? { ...pr, quantity: value } : pr)
                    );
                  }}
                />
                <button
                  onClick={async () => {
                    try {
                      await axios.put(`http://localhost:5085/api/admin/products/${p.productId}/quantity`, {
                        quantity: p.quantity ?? 0
                      });
                      alert("Количество обновлено");
                    } catch {
                      alert("Ошибка при обновлении количества");
                    }
                  }}
                  style={{
                    marginLeft: "8px",
                    background: "#4ade80",
                    border: "none",
                    padding: "4px 8px",
                    cursor: "pointer",
                    borderRadius: "4px"
                  }}
                >
                  💾
                </button>
              </td>
              <td style={td}>
                <button onClick={() => {
                  setEditId(p.productId);
                  setForm({
                    model: p.model,
                    brand: p.brand,
                    newPrice: p.newPrice,
                    availability: p.availability,
                    image: null
                  });
                  window.scrollTo({ top: 0, behavior: "smooth" });
                }} style={editBtn}>✏️</button>

                <button onClick={() => handleDelete(p.productId)} style={deleteBtn}>🗑</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

const th = {
  padding: "10px",
  textAlign: "left",
  fontWeight: "600",
  borderBottom: "2px solid #ddd"
};  

const td = {
  padding: "10px",
  borderBottom: "1px solid #eee"
};

const editBtn = {
  background: "#60a5fa",
  color: "#fff",
  border: "none",
  padding: "6px 10px",
  borderRadius: "6px",
  marginRight: "5px",
  cursor: "pointer"
};

const deleteBtn = {
  background: "#ef4444",
  color: "#fff",
  border: "none",
  padding: "6px 10px",
  borderRadius: "6px",
  cursor: "pointer"
};
