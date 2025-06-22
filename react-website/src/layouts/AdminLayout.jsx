import { Routes, Route, Link, useNavigate } from "react-router-dom";
import AdminDashboard from "../admin/AdminDashboard";
import OrdersPanel from "../admin/OrdersPanel";
import ProductManager from "../admin/ProductManager";

import ReportPage from "../admin/ReportPage";
import UsersPanel from "../admin/UsersPanel";

export default function AdminLayout() {
  const navigate = useNavigate();

  const handleLogout = () => {
    localStorage.removeItem("user");
    navigate("/login");
  };

  return (
    <div style={{ display: "flex", height: "100vh", fontFamily: "Arial, sans-serif" }}>
      {/* Sidebar */}
      <aside style={{ width: "250px", backgroundColor: "#1f2937", color: "#fff", padding: "30px 20px" }}>
        <h2 style={{ marginBottom: "30px", fontSize: "22px", fontWeight: "bold" }}>Админ-панель</h2>
        <nav>
          <ul style={{ listStyle: "none", padding: 0, lineHeight: "2.2" }}>
            <li><Link to="/admin" style={linkStyle}>🏠 Главная</Link></li>
            <li><Link to="/admin/users" style={linkStyle}>👤 Пользователи</Link></li>
            <li><Link to="/admin/products" style={linkStyle}>📦 Товары</Link></li>
            <li><Link to="/admin/orders" style={linkStyle}>🧾 Заказы</Link></li>
            <li><Link to="/admin/reports" style={linkStyle}>📊 Отчёты</Link></li>
          </ul>
        </nav>
        <button onClick={handleLogout} style={logoutButtonStyle}>🚪 Выйти</button>
      </aside>

      {/* Main Content */}
      <main style={{ flexGrow: 1, padding: "40px", background: "#f9fafb" }}>
        <Routes>
          <Route path="/" element={<AdminDashboard />} />
          <Route path="users" element={<UsersPanel />} />
          <Route path="products" element={<ProductManager />} />
          
          <Route path="orders" element={<OrdersPanel />} />
          <Route path="reports" element={<ReportPage />} />
        </Routes>
      </main>
    </div>
  );
}

const linkStyle = {
  color: "#fff",
  textDecoration: "none",
  fontSize: "16px",
  display: "block",
  padding: "8px 0",
};

const logoutButtonStyle = {
  marginTop: "40px",
  padding: "10px 16px",
  backgroundColor: "#ef4444",
  color: "#fff",
  border: "none",
  borderRadius: "6px",
  cursor: "pointer",
  fontSize: "15px",
};
