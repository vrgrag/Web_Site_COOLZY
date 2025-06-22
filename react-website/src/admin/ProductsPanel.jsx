import { useEffect, useState } from "react";
import axios from "axios";

export default function ProductsPanel() {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    axios.get("/api/products")
      .then(res => setProducts(res.data))
      .catch(err => console.error("Ошибка при загрузке продуктов", err));
  }, []);

  return (
    <div style={{
      maxWidth: '1200px',
      margin: '0 auto',
      padding: '40px 20px',
      fontFamily: "'Inter', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif",
      background: '#f4f6f9'
    }}>
      <h2 style={{ fontSize: '1.75rem', fontWeight: 700, color: '#1e293b', marginBottom: '24px' }}>
        📋 Список товаров
      </h2>
      <table style={{
        width: '100%',
        borderCollapse: 'collapse',
        background: '#ffffff',
        borderRadius: '12px',
        overflow: 'hidden',
        boxShadow: '0 4px 12px rgba(0, 0, 0, 0.05)'
      }}>
        <thead>
          <tr style={{ background: '#f8fafc', color: '#1e293b' }}>
            <th style={{ padding: '16px', textAlign: 'left', fontWeight: 600, borderBottom: '1px solid #e5e7eb' }}>ID</th>
            <th style={{ padding: '16px', textAlign: 'left', fontWeight: 600, borderBottom: '1px solid #e5e7eb' }}>Модель</th>
            <th style={{ padding: '16px', textAlign: 'left', fontWeight: 600, borderBottom: '1px solid #e5e7eb' }}>Бренд</th>
            <th style={{ padding: '16px', textAlign: 'left', fontWeight: 600, borderBottom: '1px solid #e5e7eb' }}>Цена</th>
          </tr>
        </thead>
        <tbody>
          {products.map(p => (
            <tr key={p.productId} style={{ transition: 'background 0.2s' }}>
              <td style={{ padding: '16px', borderBottom: '1px solid #e5e7eb' }}>{p.productId}</td>
              <td style={{ padding: '16px', borderBottom: '1px solid #e5e7eb' }}>{p.model}</td>
              <td style={{ padding: '16px', borderBottom: '1px solid #e5e7eb' }}>{p.brand}</td>
              <td style={{ padding: '16px', borderBottom: '1px solid #e5e7eb' }}>{p.newPrice} руб.</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
