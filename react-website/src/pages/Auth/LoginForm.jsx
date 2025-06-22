import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import './LoginForm.css';

const LoginForm = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError('');

    try {
      const response = await axios.post(
        'http://localhost:5085/api/auth/login',
        { email, password },
        { headers: { 'Content-Type': 'application/json' } }
      );

      const user = response.data;

      // Проверка только на наличие userId
      if (!user.userId) {
        throw new Error('Некорректный ответ сервера: отсутствует userId');
      }

      // Сохраняем данные
      localStorage.setItem('user', JSON.stringify(user));

      // Переход по роли
      if (user.isAdmin) {
        navigate('/admin');
      } else {
        navigate('/profile');
      }
    } catch (err) {
      const errorMessage =
        err.response?.data?.message ||
        err.response?.statusText ||
        'Ошибка входа. Проверьте email и пароль.';
      setError(errorMessage);
    }
  };

  return (
    <div className="auth-wrapper">
      <form onSubmit={handleSubmit} className="auth-form">
        <h2 className="auth-title">Вход в аккаунт</h2>

        <label className="auth-label">Email</label>
        <input
          type="email"
          className="auth-input"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          required
        />

        <label className="auth-label">Пароль</label>
        <input
          type="password"
          className="auth-input"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          required
        />

        {error && <div className="auth-error">{error}</div>}

        <button type="submit" className="auth-button">Войти</button>
        <button
          type="button"
          className="auth-link"
          onClick={() => navigate('/forgot-password')}
        >
          Забыли пароль?
        </button>
        <button
          type="button"
          className="auth-link"
          onClick={() => navigate('/register')}
        >
             Нет аккаунта, создеть его?
        </button>
      </form>
    </div>
  );
};

export default LoginForm;
