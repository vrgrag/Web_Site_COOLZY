// src/pages/DeliveryPay/DeliveryPay.jsx
import React from "react";
import "./DeliveryPay.css"; // Импортируем стили

const DeliveryPay = () => {
  return (
    <main>
      <div className="content-container">
        <h1 className="main-heading">Доставка и<br /> оплата</h1>
        <p className="description">
          Мы хотим, чтобы процесс покупки в "COOLZY" был максимально удобным для вас. Ознакомьтесь с условиями доставки и оплаты ниже.
        </p>

        <section className="delivery-section">
          <h2 className="section-title">Доставка</h2>
          <div className="delivery-info">
            <h3 className="info-title">Способы доставки</h3>
            <ul className="info-list">
              <li>Курьерская доставка по Минску — бесплатно при заказе от 200 руб.</li>
              <li>Доставка по Беларуси через "Белпочта" — от 5 руб., срок 2-5 дней.</li>
              <li>Самовывоз из магазина по адресу: г. Минск, ул. Гурского 37.</li>
            </ul>
          </div>
          <div className="delivery-info">
            <h3 className="info-title">Условия доставки</h3>
            <ul className="info-list">
              <li>Доставка осуществляется в течение 1-2 рабочих дней по Минску.</li>
              <li>При заказе до 12:00 доставка возможна в тот же день (по Минску).</li>
              <li>Вы получите уведомление о статусе доставки на email или по телефону.</li>
            </ul>
          </div>
        </section>

        <section className="payment-section">
          <h2 className="section-title">Оплата</h2>
          <div className="payment-info">
            <h3 className="info-title">Способы оплаты</h3>
            <ul className="info-list">
              <li>Наличными при получении (курьеру или в магазине).</li>
              <li>Банковской картой онлайн (Мир, MasterCard, Visa).</li>
              <li>Электронные платежи через систему "Расчёт" (ЕРИП).</li>
            </ul>
          </div>
          <div className="payment-info">
            <h3 className="info-title">Условия оплаты</h3>
            <ul className="info-list">
              <li>Оплата онлайн должна быть произведена в течение 24 часов после оформления заказа.</li>
              <li>При оплате наличными сдача предоставляется курьером.</li>
              <li>Все платежи защищены и проходят через безопасные системы.</li>
            </ul>
          </div>
        </section>

        <section className="contact-section">
          <h2 className="section-title">Есть вопросы?</h2>
          <p className="contact-text">
            Свяжитесь с нами для уточнения деталей:<br />
            Телефон: +375 (29) 133-13-13<br />
            Email: COOLZY@gmail.com
          </p>
        </section>
      </div>
    </main>
  );
};

export default DeliveryPay;
