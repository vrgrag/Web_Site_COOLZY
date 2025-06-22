// src/pages/QuestionsAnswers/QuestionsAnswers.jsx
import React from "react";
import "./QuestionsAnswers.css"; // Импортируем стили

const QuestionsAnswers = () => {
  return (
    <main>
      <div className="content-container">
        <h1 className="main-heading">Вопросы и ответы</h1>
        <p className="description">
          Здесь собраны ответы на самые популярные вопросы наших клиентов. Если вы не нашли ответа, свяжитесь с нами!
        </p>

        <section className="faq-section">
          <div className="faq-item">
            <h3 className="faq-question">1. Как оформить заказ на сайте COOLZY?</h3>
            <p className="faq-answer">
              Чтобы оформить заказ, выберите нужный товар, добавьте его в корзину, затем перейдите в корзину и следуйте инструкциям для оформления. После подтверждения заказа вы получите уведомление на email.
            </p>
          </div>

          <div className="faq-item">
            <h3 className="faq-question">2. Сколько времени занимает доставка?</h3>
            <p className="faq-answer">
              Доставка по Минску занимает 1-2 рабочих дня. По Беларуси через "Белпочта" — 2-5 дней. Точные сроки зависят от региона и выбранного способа доставки.
            </p>
          </div>

          <div className="faq-item">
            <h3 className="faq-question">3. Могу ли я вернуть товар, если он мне не подошёл?</h3>
            <p className="faq-answer">
              Да, вы можете вернуть товар в течение 14 дней с момента получения, если он не был использован и сохранена оригинальная упаковка. Подробности в разделе <a href="/return-obmen">Возврат/Обмен</a>.
            </p>
          </div>

          <div className="faq-item">
            <h3 className="faq-question">4. Как начисляются бонусы за покупки?</h3>
            <p className="faq-answer">
              За каждые 10 рублей покупки вы получаете 1 бонус. Бонусы начисляются автоматически после подтверждения заказа. Подробности в разделе <a href="/bonus-program">Бонусная программа</a>.
            </p>
          </div>

          <div className="faq-item">
            <h3 className="faq-question">5. Какие способы оплаты доступны?</h3>
            <p className="faq-answer">
              Вы можете оплатить заказ наличными при получении, банковской картой онлайн (Мир, MasterCard, Visa) или через систему "Расчёт" (ЕРИП). Подробности в разделе <a href="/delivery-pay-answ">Доставка и оплата</a>.
            </p>
          </div>
        </section>

        <section className="contact-section">
          <h2 className="section-title">Не нашли ответ?</h2>
          <p className="contact-text">
            Свяжитесь с нами для получения дополнительной информации:<br />
            Телефон: +375 (29) 133-13-13<br />
            Email: COOLZY@gmail.com
          </p>
        </section>
      </div>
    </main>
  );
};

export default QuestionsAnswers;
