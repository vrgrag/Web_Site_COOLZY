// src/pages/BonusProgram/BonusProgram.jsx
import React from "react";
import "./BonusProgram.css"; // Импортируем стили

const BonusProgram = () => {
  return (
    <main>
      <div className="content-container">
        <h1 className="main-heading">Бонусная программа</h1>
        <p className="description">
          Участвуйте в бонусной программе "COOLZY" и получайте преимущества при каждом заказе! Накопленные бонусы можно использовать для скидок на будущие покупки.
        </p>

        <section className="bonus-info-section">
          <h2 className="section-title">Как это работает?</h2>
          <p className="info-text">
            За каждый заказ вы получаете бонусы, которые начисляются в зависимости от суммы покупки. Бонусы можно тратить на оплату части заказа или обменивать на эксклюзивные предложения.
          </p>
        </section>

        <section className="bonus-rules-section">
          <h2 className="section-title">Условия программы</h2>
          <ul className="rules-list">
            <li>1 бонус начисляется за каждые 10 рублей покупки.</li>
            <li>Бонусы начисляются автоматически после подтверждения заказа.</li>
            <li>Минимальная сумма заказа для использования бонусов — 50 рублей.</li>
            <li>Бонусы действительны в течение 12 месяцев с даты начисления.</li>
            <li>Максимальная доля бонусов в одном заказе — 20% от суммы.</li>
          </ul>
        </section>

        <section className="bonus-usage-section">
          <h2 className="section-title">Как использовать бонусы?</h2>
          <ol className="usage-list">
            <li>Войдите в личный кабинет на сайте.</li>
            <li>Выберите товары и добавьте их в корзину.</li>
            <li>На странице оплаты укажите количество бонусов для списания.</li>
            <li>Подтвердите заказ, и бонусы будут применены автоматически.</li>
          </ol>
        </section>

        <section className="bonus-contact-section">
          <h2 className="section-title">Подробности</h2>
          <p className="contact-text">
            Узнайте больше о бонусной программе или уточните свой баланс:<br />
            Телефон: +375 (29) 133-13-13<br />
            Email: COOLZY@gmail.com
          </p>
        </section>
      </div>
    </main>
  );
};

export default BonusProgram;
