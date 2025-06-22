// Home.jsx
import React, { useState } from "react";
import Banner from "../../Components/Banner/Banner";
import Category from "../../Components/Category/Category";
import ProductList from "../../Components/ProductList/ProductList";
import "./Home.css";

const Home = () => {
  const [mode_category, setModeCategory] = useState("Смартфоны");

  return (
    <div className="home-page">
      <div className="container">
        {/* Баннер */}
        <Banner />

        {/* Категории товаров */}
        <section className="categories-section">
          <Category setCategory={setModeCategory} />
        </section>

        {/* Популярные товары */}
        <section className="popular-products">
          <h2 className="section-title">Популярное</h2>
          <ProductList />
        </section>
      </div>
    </div>
  );
};

export default Home; 
