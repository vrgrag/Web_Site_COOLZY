import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import './ProfilePage.css';

const ProfilePage = () => {
  const [userData, setUserData] = useState({
    username: '',
    email: '',
    password: '',
    firstName: '',
    lastName: '',
    phone: '',
    birthDate: '',
    isAdmin: false,
  });
  const [orders, setOrders] = useState([]);
  const [favorites, setFavorites] = useState([]);
  const [loading, setLoading] = useState(true);
  const navigate = useNavigate();

  useEffect(() => {
    const storedUser = JSON.parse(localStorage.getItem("user"));
    if (!storedUser?.userId) {
      return navigate("/login");
    }

    const fetchProfile = async () => {
      try {
        const [userRes, ordersRes, favRes] = await Promise.all([
          fetch(`http://localhost:5085/api/auth/${storedUser.userId}`),
          fetch(`http://localhost:5085/api/orders/user/${storedUser.userId}`),
          fetch(`http://localhost:5085/api/favorite/${storedUser.userId}`),
        ]);

        if (!userRes.ok || !ordersRes.ok || !favRes.ok) {
          throw new Error(`Ошибка загрузки данных`);
        }

        const user = await userRes.json();
        setUserData({
          username: user.username || '',
          email: user.email || '',
          password: '',
          firstName: user.firstName || '',
          lastName: user.lastName || '',
          phone: user.phone || '',
          birthDate: user.birthDate?.slice(0, 10) || '',
          isAdmin: user.isAdmin || false,
        });

        const orderData = await ordersRes.json();
        const favoriteData = await favRes.json();

     const parsedOrders = await Promise.all(
  orderData.map(async (order) => {
    let pdfUrl = null;
    try {
      const pdfRes = await fetch(`http://localhost:5085/api/orders/pdf/${order.orderId}`);
      const pdfData = await pdfRes.json();
      pdfUrl = "http://localhost:5085" + pdfData.pdfUrl;
    } catch (e) {
      console.warn("Не удалось загрузить PDF для заказа", order.orderId);
    }

    const items = (order.items || []).map(item => {
      const product = item.product || {};
      return {
        id: item.orderItemId,
        productId: product.productId || item.productId,
        name: product.model || product.name || "Без названия",
        image: (product.images && product.images[0]?.imageUrl) || "/img/placeholder.png",
        price: item.price ?? product.newPrice ?? 0,
        quantity: item.quantity || 1,
      };
    });

    const total = items.reduce((sum, i) => sum + i.price * i.quantity, 0);

    return {
      id: order.orderId,
      date: order.createdAt,
      totalPrice: total,
      pdfUrl,
      items
    };
  })
);

        setOrders(parsedOrders);
        setFavorites(favoriteData);
        setLoading(false);
      } catch (err) {
        alert("Ошибка загрузки профиля");
        setLoading(false);
      }
    };

    fetchProfile();
  }, [navigate]);

  const handleChange = e => {
    const { name, value } = e.target;
    setUserData(prev => ({ ...prev, [name]: value }));
  };

  const handleSave = async () => {
    const storedUser = JSON.parse(localStorage.getItem("user"));
    if (!storedUser?.userId) return;

    try {
      const res = await fetch(`http://localhost:5085/api/auth/update`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ userId: storedUser.userId, ...userData }),
      });

      if (res.ok) {
        const updated = await res.json();
        localStorage.setItem('user', JSON.stringify(updated));
        alert('Профиль обновлён');
      } else {
        const err = await res.text();
        alert('Ошибка при обновлении профиля: ' + err);
      }
    } catch (err) {
      alert('Ошибка при сохранении');
    }
  };

  const handleLogout = () => {
    localStorage.removeItem('user');
    navigate('/login');
  };

  const handleRemoveFavorite = async (productId) => {
    const storedUser = JSON.parse(localStorage.getItem('user'));
    if (!storedUser?.userId) return;

    try {
      const res = await fetch(`http://localhost:5085/api/favorite/${storedUser.userId}/${productId}`, {
        method: 'DELETE',
      });

      if (res.ok) {
        setFavorites(prev => prev.filter(fav => fav.productId !== productId));
        alert('Удалено из избранного');
      } else {
        alert('Ошибка при удалении');
      }
    } catch {
      alert('Ошибка при удалении');
    }
  };

  if (loading) return <div style={{ textAlign: 'center', fontSize: '18px' }}>Загрузка...</div>;

  return (
    <div className="profile-wrapper">
      <h2 className="profile-title">{userData.isAdmin ? 'Панель администратора' : 'Личный кабинет'}</h2>

      {userData.isAdmin && (
        <div className="admin-section">
          <h3>Управление</h3>
          <button className="admin-btn" onClick={() => navigate('/admin/users')}>Пользователи</button>
          <button className="admin-btn" onClick={() => navigate('/admin/orders')}>Заказы</button>
          <button className="admin-btn" onClick={() => navigate('/admin/products')}>Товары</button>
        </div>
      )}

      <div className="profile-form">
        <div className="form-group"><label>Имя пользователя</label>
          <input type="text" name="username" value={userData.username} onChange={handleChange} className="checkout-input" />
        </div>
        <div className="form-group"><label>Email</label>
          <input type="email" name="email" value={userData.email} onChange={handleChange} className="checkout-input" />
        </div>
        <div className="form-group"><label>Пароль</label>
          <input type="password" name="password" value={userData.password} onChange={handleChange} className="checkout-input" />
        </div>
        <div className="form-group"><label>Имя</label>
          <input type="text" name="firstName" value={userData.firstName} onChange={handleChange} className="checkout-input" />
        </div>
        <div className="form-group"><label>Фамилия</label>
          <input type="text" name="lastName" value={userData.lastName} onChange={handleChange} className="checkout-input" />
        </div>
        <div className="form-group"><label>Телефон</label>
          <input type="tel" name="phone" value={userData.phone} onChange={handleChange} className="checkout-input" />
        </div>
        <div className="form-group"><label>Дата рождения</label>
          <input type="date" name="birthDate" value={userData.birthDate} onChange={handleChange} className="checkout-input" />
        </div>

        <div className="profile-actions">
          <button className="checkout-btn" onClick={handleSave}>Сохранить</button>
          <button className="logout-btn" onClick={handleLogout}>Выйти</button>
        </div>
      </div>

      {!userData.isAdmin && (
        <>
          <div className="profile-section-title">Мои заказы</div>
          {orders.length === 0 ? (
            <p style={{ textAlign: 'center' }}>У вас нет заказов.</p>
          ) : (
            orders.map(order => (
              <div key={order.id} style={{ marginBottom: '30px' }}>
                <h4>
                  Заказ №{order.id} от {new Date(order.date).toLocaleDateString()} — {order.totalPrice.toLocaleString()} BYN
                </h4>
                {order.pdfUrl && (
                  <a href={`http://localhost:5085${order.pdfUrl}`} target="_blank" rel="noreferrer">
                    Скачать гарантийный талон
                  </a>
                )}
                <div className="cart-grid">
                  {order.items.map(item => (
                    <div key={item.id} className="cart-item" onClick={() => navigate(`/products/${item.productId}`)}>
                      <img src={item.image || '/img/placeholder.png'} alt={item.name} className="cart-image" />
                      <h3 className="cart-title">{item.name}</h3>
                      <div className="new-price">{item.price} BYN</div>
                      <div className="quantity">Количество: {item.quantity}</div>
                    </div>
                  ))}
                </div>
              </div>
            ))
          )}

          <div className="profile-section-title">Избранное</div>
          {favorites.length === 0 ? (
            <p style={{ textAlign: 'center' }}>Нет избранных товаров.</p>
          ) : (
            <div className="cart-grid">
              {favorites.map(fav => {
                const product = fav.product;
                if (!product) return null;

                return (
                 <div
  key={fav.productId}
  className="cart-item"
  onClick={() => navigate(`/products/${fav.productId}`)}
  style={{ cursor: 'pointer' }}
>
  <img src={product.imageUrl || '/img/placeholder.png'} alt={product.model || 'Товар'} className="cart-image" />
  <h3 className="cart-title">{product.model || product.name || 'Без названия'}</h3>
  <div className="new-price">{product.newPrice || 0} BYN</div>
  <button
    onClick={(e) => {
      e.stopPropagation(); // чтобы клик по кнопке не переходил на товар
      handleRemoveFavorite(fav.productId);
    }}
    className="remove-favorite-btn"
  >
    Удалить
  </button>
</div>

                );
              })}
            </div>
          )}
        </>
      )}
    </div>
  );
};

export default ProfilePage;
