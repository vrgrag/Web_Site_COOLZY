// Catalog.jsx
import { Route, Routes } from 'react-router-dom';
import Header from '../../Components/Header/Header';
import CategoryPage from '../CategoryPage/CategoryPage';

const Catalog = () => {
  return (
    <div>
      <Header />
      <Routes>
        <Route path="/Смартфоны" element={<CategoryPage category="Смартфоны" />} />
        <Route path="/Ноутбуки" element={<CategoryPage category="Ноутбуки" />} />
        <Route path="/Планшеты" element={<CategoryPage category="Планшеты" />} />
        <Route path="/Телевизоры" element={<CategoryPage category="Телевизоры" />} />
        <Route path="/Колонки" element={<CategoryPage category="Колонки" />} />
      </Routes>
    </div>
  );
};

export default Catalog;
