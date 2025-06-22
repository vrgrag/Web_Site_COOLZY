import React, { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import "./LoginForm.css";

const RegisterForm = () => {
  const [form, setForm] = useState({
    username: "",
    email: "",
    password: ""
  });
  const [error, setError] = useState("");

  const navigate = useNavigate();

  const handleChange = (e) => {
    const { name, value } = e.target;
    setForm((prev) => ({ ...prev, [name]: value }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError("");

    try {
      const response = await axios.post("http://localhost:5085/api/auth/register", form);
      const user = response.data;
      localStorage.setItem("user", JSON.stringify(user));
      navigate("/profile");
    } catch (err) {
      const msg = err.response?.data;

      if (typeof msg === "string") {
        setError(msg);
      } else if (typeof msg === "object" && msg?.errors) {
        const firstError = Object.values(msg.errors)[0][0];
        setError(firstError);
      } else {
        setError("Ошибка регистрации.");
      }
    }
  };

  return (
    <div className="auth-wrapper">
      <form onSubmit={handleSubmit} className="auth-form">
        <h2 className="auth-title">Регистрация</h2>

        <label className="auth-label">Имя пользователя</label>
        <input
          type="text"
          name="username"
          className="auth-input"
          value={form.username}
          onChange={handleChange}
          required
        />

        <label className="auth-label">Email</label>
        <input
          type="email"
          name="email"
          className="auth-input"
          value={form.email}
          onChange={handleChange}
          required
        />

        <label className="auth-label">Пароль</label>
        <input
          type="password"
          name="password"
          className="auth-input"
          value={form.password}
          onChange={handleChange}
          required
        />

        {error && <div className="auth-error">{error}</div>}

        <button type="submit" className="auth-button">Зарегистрироваться</button>
        <button
          type="button"
          className="auth-link"
          onClick={() => navigate("/login")}
        >
          Уже есть аккаунт?
        </button>
      </form>
    </div>
  );
};

export default RegisterForm;
