// src/pages/ReturnObmen/ReturnObmen.jsx
import React from "react";
import "./ReturnObmen.css"; // Импортируем стили

const ReturnObmen = () => {
  return (
    <main>
      <div className="content-container">
        <h1 className="main-heading">Возврат и обмен</h1>
        <p className="description">
          Мы стремимся обеспечить вас лучшим сервисом. Ниже приведены условия возврата и обмена товаров в интернет-магазине "COOLZY".
        </p>

        <section className="return-policy-section">
          <h2 className="section-title">Условия возврата</h2>
          <ul className="policy-list">
            <li>Возврат товара возможен в течение 14 дней с момента получения заказа.</li>
            <li>Товар должен быть в оригинальной упаковке и не использован.</li>
            <li>Возврат возможен только при наличии чека или электронного подтверждения покупки.</li>
            <li>Стоимость доставки при возврате не компенсируется.</li>
          </ul>
        </section>

        <section className="exchange-policy-section">
          <h2 className="section-title">Условия обмена</h2>
          <ul className="policy-list">
            <li>Обмен товара возможен в течение 14 дней с момента получения заказа.</li>
            <li>Товар должен быть в надлежащем состоянии и иметь все ярлыки.</li>
            <li>Обмен осуществляется на аналогичный товар или товар другой модели при наличии.</li>
            <li>Доставка при обмене оплачивается покупателем.</li>
          </ul>
        </section>

        <section className="return-process-section">
          <h2 className="section-title">Процесс возврата или обмена</h2>
          <ol className="process-list">
            <li>Свяжитесь с нами по телефону +375 (29) 133-13-13 или email: COOLZY@gmail.com.</li>
            <li>Укажите номер заказа и причины возврата/обмена.</li>
            <li>Отправьте товар по адресу: г. Минск, ул. Гурского 37.</li>
            <li>После получения товара мы обработаем ваш запрос в течение 7 рабочих дней.</li>
          </ol>
        </section>
      </div>
    </main>
  );
};

export default ReturnObmen;
