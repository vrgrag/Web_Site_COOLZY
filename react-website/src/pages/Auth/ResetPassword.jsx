import React, { useState } from "react";
import axios from "axios";
import "./LoginForm.css";
import { useNavigate } from "react-router-dom";

const ResetPassword = () => {
  const [email, setEmail] = useState("");
  const [newPassword, setNewPassword] = useState("");
  const [status, setStatus] = useState("");
  const [error, setError] = useState("");
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError("");
    setStatus("");

    try {
      await axios.post("http://localhost:5085/api/auth/reset", {
        email,
        newPassword,
      });
      setStatus("Пароль успешно обновлён.");
      setTimeout(() => navigate("/login"), 2000);
    } catch (err) {
      setError(err.response?.data || "Ошибка сброса пароля.");
    }
  };

  return (
    <div className="auth-wrapper">
      <form onSubmit={handleSubmit} className="auth-form">
        <h2 className="auth-title">Сброс пароля</h2>

        <label className="auth-label">Email</label>
        <input
          type="email"
          className="auth-input"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          required
        />

        <label className="auth-label">Новый пароль</label>
        <input
          type="password"
          className="auth-input"
          value={newPassword}
          onChange={(e) => setNewPassword(e.target.value)}
          required
        />

        {status && <div className="auth-error" style={{ color: "green" }}>{status}</div>}
        {error && <div className="auth-error">{error}</div>}

        <button type="submit" className="auth-button">Сохранить новый пароль</button>
        <button type="button" className="auth-link" onClick={() => navigate("/login")}>
          Назад ко входу
        </button>
      </form>
    </div>
  );
};

export default ResetPassword;
