import { useEffect, useState } from "react";
import axios from "axios";
import { Line, Pie } from 'react-chartjs-2';
import {
  Chart as ChartJS,
  LineElement,
  CategoryScale,
  LinearScale,
  PointElement,
  ArcElement,
  Title,
  Tooltip,
  Legend
} from 'chart.js';

ChartJS.register(LineElement, CategoryScale, LinearScale, PointElement, ArcElement, Title, Tooltip, Legend);

export default function ReportPage() {
  const [orders, setOrders] = useState([]);
  const [productsStats, setProductsStats] = useState({ total: 0, inStock: 0 });
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);

  useEffect(() => {
    setIsLoading(true);
    Promise.all([
      axios.get("http://localhost:5085/api/orders"),
      axios.get("http://localhost:5085/api/products")
    ])
      .then(([ordersRes, productsRes]) => {
        setOrders(ordersRes.data);
        const products = productsRes.data;
        const inStock = products.filter(p => p.availability === "В наличии").length;
        setProductsStats({ total: products.length, inStock });
      })
      .catch(err => {
        console.error("Ошибка при загрузке данных", err);
        setError("Не удалось загрузить данные. Попробуйте позже.");
      })
      .finally(() => setIsLoading(false));
  }, []);

  const handleExportOrders = () => {
    window.open("http://localhost:5085/api/admin/reports/orders", "_blank");
  };

  const handleExportUsers = () => {
    window.open("http://localhost:5085/api/admin/reports/users", "_blank");
  };

  const getOrdersChartData = () => {
    const grouped = {};

    orders.forEach(order => {
      const date = new Date(order.orderDate || order.createdAt).toLocaleDateString();
      grouped[date] = (grouped[date] || 0) + 1;
    });

    const labels = Object.keys(grouped).sort((a, b) => new Date(a) - new Date(b));
    const data = labels.map(label => grouped[label]);

    return {
      labels,
      datasets: [
        {
          label: 'Количество заказов',
          data,
          fill: false,
          borderColor: '#2563eb',
          tension: 0.2
        }
      ]
    };
  };

  const getProductsChartData = () => ({
    labels: ['В наличии', 'Нет в наличии'],
    datasets: [{
      data: [productsStats.inStock, productsStats.total - productsStats.inStock],
      backgroundColor: ['#10b981', '#ef4444'],
      borderColor: '#ffffff',
      borderWidth: 2
    }]
  });

  const btn = {
    background: '#2563eb',
    color: '#fff',
    padding: '12px 24px',
    fontSize: '1rem',
    border: 'none',
    borderRadius: '8px',
    cursor: 'pointer',
    maxWidth: '300px',
    fontWeight: 500,
    transition: 'background 0.2s'
  };

  return (
    <div style={{
      maxWidth: '1200px',
      margin: '0 auto',
      padding: '40px 20px',
      fontFamily: "'Inter', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif",
      background: '#f4f6f9',
      minHeight: '100vh'
    }}>
      <h2 style={{ fontSize: '1.75rem', fontWeight: 700, color: '#1e293b', marginBottom: '24px' }}>
        📊 Отчёты
      </h2>

      {isLoading ? (
        <div style={{ textAlign: 'center', padding: '40px', color: '#6b7280', fontSize: '1.125rem' }}>
          Загрузка данных...
        </div>
      ) : error ? (
        <div style={{ textAlign: 'center', padding: '40px', color: '#ef4444', fontSize: '1.125rem' }}>
          {error}
        </div>
      ) : (
        <>
          <div style={{ marginTop: '24px', marginBottom: '32px', background: '#ffffff', padding: '24px', borderRadius: '12px', boxShadow: '0 4px 12px rgba(0, 0, 0, 0.05)' }}>
            <h3 style={{ fontSize: '1.25rem', fontWeight: 600, color: '#1e293b', marginBottom: '12px' }}>
              📦 Статистика товаров
            </h3>
            <p style={{ fontSize: '1rem', color: '#6b7280', marginBottom: '8px' }}>
              Общее количество товаров: <strong>{productsStats.total}</strong>
            </p>
            <p style={{ fontSize: '1rem', color: '#6b7280' }}>
              В наличии: <strong>{productsStats.inStock}</strong> ({((productsStats.inStock / productsStats.total) * 100).toFixed(1)}%)
            </p>
          </div>

          <div style={{ marginBottom: '40px', background: '#ffffff', padding: '24px', borderRadius: '12px', boxShadow: '0 4px 12px rgba(0, 0, 0, 0.05)' }}>
            <h3 style={{ fontSize: '1.25rem', fontWeight: 600, color: '#1e293b', marginBottom: '16px' }}>
              📊 Наличие товаров
            </h3>
            <div style={{ maxWidth: '300px', margin: '0 auto' }}>
              <Pie
                data={getProductsChartData()}
                options={{
                  plugins: {
                    legend: { labels: { font: { family: "'Inter', sans-serif", size: 14 } } },
                    tooltip: { backgroundColor: '#1e293b', titleFont: { family: "'Inter', sans-serif" }, bodyFont: { family: "'Inter', sans-serif" } }
                  }
                }}
              />
            </div>
          </div>

          <div style={{ marginBottom: '40px', background: '#ffffff', padding: '24px', borderRadius: '12px', boxShadow: '0 4px 12px rgba(0, 0, 0, 0.05)' }}>
            <h3 style={{ fontSize: '1.25rem', fontWeight: 600, color: '#1e293b', marginBottom: '16px' }}>
              📈 График заказов по дате
            </h3>
            <Line
              data={getOrdersChartData()}
              options={{
                plugins: {
                  legend: { labels: { font: { family: "'Inter', sans-serif", size: 14 } } },
                  tooltip: { backgroundColor: '#1e293b', titleFont: { family: "'Inter', sans-serif" }, bodyFont: { family: "'Inter', sans-serif" } }
                },
                scales: {
                  x: { grid: { color: '#e5e7eb' }, ticks: { color: '#6b7280', font: { family: "'Inter', sans-serif" } } },
                  y: { grid: { color: '#e5e7eb' }, ticks: { color: '#6b7280', font: { family: "'Inter', sans-serif" } } }
                }
              }}
            />
          </div>

          <div style={{ display: 'flex', flexDirection: 'column', gap: '16px' }}>
            <button
              onClick={handleExportOrders}
              style={btn}
              onMouseOver={(e) => (e.target.style.background = '#1d4ed8')}
              onMouseOut={(e) => (e.target.style.background = '#2563eb')}
            >
              📥 Скачать Excel — Заказы
            </button>
            <button
              onClick={handleExportUsers}
              style={btn}
              onMouseOver={(e) => (e.target.style.background = '#1d4ed8')}
              onMouseOut={(e) => (e.target.style.background = '#2563eb')}
            >
              📥 Скачать Excel — Пользователи
            </button>
          </div>
        </>
      )}
    </div>
  );
}
