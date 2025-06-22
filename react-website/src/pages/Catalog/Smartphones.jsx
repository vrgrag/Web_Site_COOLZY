import React, { useEffect, useState } from 'react';
import ProductCard from '../../Components/ProductCard/ProductCard';
import Filters from '../../Components/Filters/Filters';
import '../CategoryPage/CategoryPage.css';

const Smartphones = () => {
  const [products, setProducts] = useState([]);
  const [filters, setFilters] = useState({
    brand: '',
    ram: '',
    storage: '',
    minPrice: '',
    maxPrice: ''
  });

  const handleFilterChange = (name, value) => {
    setFilters(prev =>
      name === 'reset'
        ? { brand: '', ram: '', storage: '', minPrice: '', maxPrice: '' }
        : { ...prev, [name]: value }
    );
  };

  useEffect(() => {
    const query = new URLSearchParams(filters).toString();
    fetch(`http://localhost:5085/api/products/category/Смартфоны?${query}`)
      .then(res => res.json())
      .then(data => {
        if (Array.isArray(data)) {
          setProducts(data);
        } else {
          console.error("Ожидался массив, но получено:", data);
          setProducts([]);
        }
      })
      .catch(err => {
        console.error("Ошибка загрузки:", err);
        setProducts([]);
      });
  }, [filters]);

  return (
    <div className="category-page">
      <div className="filters-panel">
        <Filters category="Смартфоны" filters={filters} onFilterChange={handleFilterChange} />
      </div>
      <div className="category-catalog">
        <h1>Каталог смартфонов</h1>
        <div className="product-grid">
          {products.map(p => (
            <ProductCard
              key={p.productId}
              id={p.productId}
              img={p.images?.[0]?.imageUrl}
              model={p.model}
              oldPrice={p.oldPrice}
              newPrice={p.newPrice}
              availability={p.availability}
              discount={
                p.oldPrice > p.newPrice
                  ? Math.round(((p.oldPrice - p.newPrice) / p.oldPrice) * 100)
                  : 0
              }
            />
          ))}
        </div>
      </div>
    </div>
  );
};

export default Smartphones;
