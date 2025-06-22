import { useEffect, useState } from "react";
import axios from "axios";

export default function UsersPanel() {
  const [users, setUsers] = useState([]);
  const [filtered, setFiltered] = useState([]);
  const [search, setSearch] = useState("");

  useEffect(() => {
    load();
  }, []);

  const load = () => {
    axios.get("http://localhost:5085/api/admin/users")
      .then(res => {
        setUsers(res.data);
        setFiltered(res.data);
      });
  };

  const handleSearch = () => {
    const query = search.toLowerCase().trim();
    setFiltered(users.filter(u =>
      u.email.toLowerCase().includes(query) ||
      u.username.toLowerCase().includes(query)
    ));
  };

  const th = {
    padding: '16px',
    textAlign: 'left',
    fontWeight: 600,
    borderBottom: '1px solid #e5e7eb',
    color: '#1e293b'
  };

  const td = {
    padding: '16px',
    borderBottom: '1px solid #e5e7eb',
    verticalAlign: 'middle'
  };

  const deleteBtn = {
    background: '#ef4444',
    color: '#fff',
    border: 'none',
    padding: '8px 12px',
    borderRadius: '8px',
    cursor: 'pointer',
    fontWeight: 500,
    transition: 'background 0.2s'
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
        👤 Пользователи
      </h2>
      <div style={{ display: 'flex', gap: '12px', marginBottom: '24px', flexWrap: 'wrap' }}>
        <input
          type="text"
          placeholder="Поиск по email или имени..."
          value={search}
          onChange={(e) => setSearch(e.target.value)}
          style={{
            padding: '12px',
            border: '1px solid #e5e7eb',
            borderRadius: '8px',
            fontSize: '1rem',
            flex: '1',
            minWidth: '200px'
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
          🔍
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
      <table style={{
        width: '100%',
        borderCollapse: 'collapse',
        background: '#ffffff',
        borderRadius: '12px',
        overflow: 'hidden',
        boxShadow: '0 4px 12px rgba(0, 0, 0, 0.05)'
      }}>
        <thead>
          <tr style={{ background: '#f8fafc' }}>
            <th style={th}>ID</th>
            <th style={th}>Email</th>
            <th style={th}>Имя</th>
            <th style={th}>Действия</th>
          </tr>
        </thead>
        <tbody>
          {filtered.map(u => (
            <tr key={u.userId} style={{ transition: 'background 0.2s' }}>
              <td style={td}>{u.userId}</td>
              <td style={td}>{u.email}</td>
              <td style={td}>{u.username}</td>
              <td style={td}>
                <button
                  onClick={() => {
                    if (window.confirm('Удалить пользователя?'))
                      axios.delete(`http://localhost:5085/api/admin/users/${u.userId}`).then(load);
                  }}
                  style={deleteBtn}
                  onMouseOver={(e) => (e.target.style.background = '#dc2626')}
                  onMouseOut={(e) => (e.target.style.background = '#ef4444')}
                >
                  🗑
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
