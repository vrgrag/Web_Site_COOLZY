import { useEffect, useState } from "react";
import axios from "axios";

export default function OrdersPanel() {
  const [orders, setOrders] = useState([]);
  const [filtered, setFiltered] = useState([]);
  const [orderIdSearch, setOrderIdSearch] = useState("");
  const [productNameSearch, setProductNameSearch] = useState("");
  const [dateFrom, setDateFrom] = useState("");
  const [dateTo, setDateTo] = useState("");

  useEffect(() => {
    load();
  }, []);

  const load = () => {
    axios.get("http://localhost:5085/api/admin/orders")
      .then(res => {
        setOrders(res.data);
        setFiltered(res.data);
      });
  };

  const handleSearch = () => {
    let result = [...orders];

    if (orderIdSearch.trim()) {
      result = result.filter(o =>
        o.orderId.toString().includes(orderIdSearch.trim())
      );
    }

    if (productNameSearch.trim()) {
      const keyword = productNameSearch.trim().toLowerCase();
      result = result.filter(o =>
        o.items?.some(i =>
          (i.model || "").toLowerCase().includes(keyword)
        )
      );
    }

    if (dateFrom) {
      result = result.filter(o => new Date(o.createdAt) >= new Date(dateFrom));
    }
    if (dateTo) {
      result = result.filter(o => new Date(o.createdAt) <= new Date(dateTo));
    }

    setFiltered(result);
  };

  const handleDelete = async (id) => {
    if (!window.confirm("Удалить заказ?")) return;
    await axios.delete(`http://localhost:5085/api/admin/orders/${id}`);
    load();
  };

  return (
    <div style={{
      maxWidth: '1200px',
      margin: '0 auto',
      padding: '40px 20px',
      fontFamily: "'Inter', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif",
      background: '#f4f6f9'
    }}>
      <h2 style={{ fontSize: '1.75rem', fontWeight: 700, color: '#1e293b', marginBottom: '24px' }}>
        📦 Заказы
      </h2>
      <div style={{ display: 'flex', gap: '12px', marginBottom: '24px', flexWrap: 'wrap' }}>
        <input
          type="text"
          placeholder="Поиск по ID заказа..."
          value={orderIdSearch}
          onChange={(e) => setOrderIdSearch(e.target.value)}
          style={{
            padding: '12px',
            border: '1px solid #e5e7eb',
            borderRadius: '8px',
            fontSize: '1rem',
            flex: '1',
            minWidth: '200px'
          }}
        />
        <input
          type="text"
          placeholder="Поиск по названию товара..."
          value={productNameSearch}
          onChange={(e) => setProductNameSearch(e.target.value)}
          style={{
            padding: '12px',
            border: '1px solid #e5e7eb',
            borderRadius: '8px',
            fontSize: '1rem',
            flex: '1',
            minWidth: '200px'
          }}
        />
        <input
          type="date"
          value={dateFrom}
          onChange={(e) => setDateFrom(e.target.value)}
          style={{
            padding: '12px',
            border: '1px solid #e5e7eb',
            borderRadius: '8px',
            fontSize: '1rem'
          }}
        />
        <input
          type="date"
          value={dateTo}
          onChange={(e) => setDateTo(e.target.value)}
          style={{
            padding: '12px',
            border: '1px solid #e5e7eb',
            borderRadius: '8px',
            fontSize: '1rem'
          }}
        />
        <button
          onClick={handleSearch}
          style={{
            padding: '12px 20px',
            background: '#2563eb',
            color: '#fff',
            border: 'none',
            borderRadius: '8px',
            cursor: 'pointer',
            fontWeight: 500,
            transition: 'background 0.2s'
          }}
          onMouseOver={(e) => (e.target.style.background = '#1d4ed8')}
          onMouseOut={(e) => (e.target.style.background = '#2563eb')}
        >
          🔍 Найти
        </button>
        <button
          onClick={load}
          style={{
            padding: '12px 20px',
            background: '#6b7280',
            color: '#fff',
            border: 'none',
            borderRadius: '8px',
            cursor: 'pointer',
            fontWeight: 500,
            transition: 'background 0.2s'
          }}
          onMouseOver={(e) => (e.target.style.background = '#4b5563')}
          onMouseOut={(e) => (e.target.style.background = '#6b7280')}
        >
          🔄 Сброс
        </button>
      </div>

      {filtered.map(o => (
        <div
          key={o.orderId}
          style={{
            marginBottom: '24px',
            padding: '24px',
            border: '1px solid #e5e7eb',
            borderRadius: '12px',
            background: '#ffffff',
            boxShadow: '0 4px 12px rgba(0, 0, 0, 0.05)',
            transition: 'transform 0.2s'
          }}
          onMouseOver={(e) => (e.currentTarget.style.transform = 'translateY(-4px)')}
          onMouseOut={(e) => (e.currentTarget.style.transform = 'translateY(0)')}
        >
          <div style={{ fontWeight: 600, color: '#1e293b' }}><strong>ID:</strong> {o.orderId}</div>
          <div style={{ color: '#6b7280' }}><strong>Дата:</strong> {new Date(o.createdAt).toLocaleString()}</div>
          <div style={{ color: '#6b7280' }}><strong>Пользователь:</strong> {o.user.username} ({o.user.email})</div>
          <div style={{ marginTop: '12px' }}>
            <strong style={{ color: '#1e293b' }}>Товары:</strong>
            <ul style={{ paddingLeft: '20px', color: '#4b5563' }}>
              {o.items.map(i => (
                <li key={i.productId}>
                  {i.model} — {i.quantity} × {i.price} руб.
                </li>
              ))}
            </ul>
          </div>
          <div style={{ fontWeight: 600, color: '#1e293b', marginTop: '12px' }}><strong>Сумма:</strong> {o.total} руб.</div>
          <button
            onClick={() => handleDelete(o.orderId)}
            style={{
              background: '#ef4444',
              color: '#fff',
              border: 'none',
              padding: '10px 16px',
              borderRadius: '8px',
              cursor: 'pointer',
              marginTop: '12px',
              fontWeight: 500,
              transition: 'background 0.2s'
            }}
            onMouseOver={(e) => (e.target.style.background = '#dc2626')}
            onMouseOut={(e) => (e.target.style.background = '#ef4444')}
          >
            🗑 Удалить
          </button>
        </div>
      ))}
    </div>
  );
}
 