// src/pages/AboutUs/AboutUs.jsx
import React, { useEffect } from "react";
import "./AboutUs.css"; // Импортируем стили

const AboutUs = () => {
  // Эффект для анимации счетчиков
  useEffect(() => {
    const counters = [
      { id: "counter1", end: 50, duration: 2000 }, // 50 тысяч доставок
      { id: "counter2", end: 30, duration: 2000 }, // 30 компаний
      { id: "counter3", end: 2, duration: 2000 },  // 2 тысячи сотрудников
      { id: "counter4", end: 5, duration: 2000 },  // 5 миллионов продукции
    ];

    counters.forEach(({ id, end, duration }) => {
      const element = document.getElementById(id);
      let start = 0;
      const increment = end / (duration / 50); // Скорость анимации
      const animate = () => {
        start += increment;
        if (start >= end) {
          element.textContent = end;
          return;
        }
        element.textContent = Math.floor(start);
        setTimeout(animate, 50);
      };
      animate();
    });
  }, []);

  return (
    <main>
      <div className="container text-center my-5">
        <p className="description">
          Каждая деталь создана для тех, кто ценит <br />инновации, надежность и передовые технологии.
        </p>
        <h1 className="main-heading">COOLZY</h1>

        <div className="row justify-content-center gap-extended mt-5">
          <div className="col-md-5 col-6 mb-4 d-flex align-items-center justify-content-start">
            <p className="stats" id="counter1">0</p>
            <div className="stats-description-container">
              <p className="stats-description">
                тысяч доставок в год во всех городах Беларуси
              </p>
            </div>
          </div>
          <div className="col-md-4 col-6 mb-4 d-flex align-items-center justify-content-start">
            <p className="stats" id="counter2">0</p>
            <div className="stats-description-container">
              <p className="stats-description">великих компаний в сотрудничестве</p>
            </div>
          </div>
        </div>

        <div className="row justify-content-center mar-extended mt-5">
          <div className="col-md-3 col-6 mb-4 d-flex align-items-center justify-content-start extra-margin-right">
            <p className="stats" id="counter3">0</p>
            <div className="stats-description-container">
              <p className="stats-description">тысячи сотрудников</p>
            </div>
          </div>
          <div className="col-md-4 col-6 mb-4 d-flex align-items-center justify-content-start">
            <p className="stats" id="counter4">0</p>
            <div className="stats-description-container">
              <p className="stats-description">миллионов продукции в год</p>
            </div>
          </div>
        </div>
      </div>
    </main>
  );
};

export default AboutUs;
