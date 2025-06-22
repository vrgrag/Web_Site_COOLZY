import React, { useState } from "react";
import axios from "axios";
import "./LoginForm.css";
import { useNavigate } from "react-router-dom";

const ForgotPassword = () => {
  const [email, setEmail] = useState("");
  const [status, setStatus] = useState("");
  const [error, setError] = useState("");
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError("");
    setStatus("");

    try {
      await axios.post("http://localhost:5085/api/auth/forgot", { email });
      setStatus("Инструкция по сбросу пароля отправлена на email.");
    } catch (err) {
      setError(err.response?.data || "Ошибка при сбросе пароля.");
    }
  };

  return (
    <div className="auth-wrapper">
      <form onSubmit={handleSubmit} className="auth-form">
        <h2 className="auth-title">Восстановление пароля</h2>

        <label className="auth-label">Email</label>
        <input
          type="email"
          className="auth-input"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          required
        />

        {status && <div className="auth-error" style={{ color: "green" }}>{status}</div>}
        {error && <div className="auth-error">{error}</div>}

        <button type="submit" className="auth-button">Отправить</button>
        <button type="button" className="auth-link" onClick={() => navigate("/login")}>
          Назад к входу
        </button>
      </form>
    </div>
  );
};

export default ForgotPassword;
