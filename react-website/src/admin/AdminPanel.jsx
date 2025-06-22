import { useNavigate } from "react-router-dom";
import "./AdminPanelStyles.css";

export default function AdminDashboard() {
  const navigate = useNavigate();

  return (
    <div className="admin-dashboard">
      <header className="admin-header">
        <h1 className="dashboard-title">👋 Админ-панель</h1>
        <p className="dashboard-subtitle">
          Управление пользователями, товарами, заказами и отчетами
        </p>
      </header>

      <div className="dashboard-grid">
        <div className="dashboard-card" onClick={() => navigate("/admin/users")}>👤 Пользователи</div>
        <div className="dashboard-card" onClick={() => navigate("/admin/products")}>📦 Товары</div>
        <div className="dashboard-card" onClick={() => navigate("/admin/orders")}>🧾 Заказы</div>
        <div className="dashboard-card" onClick={() => navigate("/admin/reports")}>📊 Отчёты</div>
      </div>
    </div>
  );
}
