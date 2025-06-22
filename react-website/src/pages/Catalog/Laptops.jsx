import React, { useEffect, useState } from 'react';
import ProductCard from '../../Components/ProductCard/ProductCard';
import Filters from '../../Components/Filters/Filters';
import '../CategoryPage/CategoryPage.css';

const Laptops = () => {
  const [products, setProducts] = useState([]);
  const [filters, setFilters] = useState({ brand: '', ram: '', storage: '', minPrice: '', maxPrice: '' });

  const handleFilterChange = (name, value) => {
    setFilters(prev => name === 'reset' ? { brand: '', ram: '', storage: '', minPrice: '', maxPrice: '' } : { ...prev, [name]: value });
  };

  useEffect(() => {
    const query = new URLSearchParams(filters).toString();
    fetch(`http://localhost:5085/api/products/category/Ноутбуки?${query}`)
      .then(res => res.json())
      .then(data => {
        const normalized = data.map(item => ({
          productId: item.productId || item.id,
          images: item.images || (item.img ? [{ imageUrl: item.img }] : []),
          model: item.model || item.name,
          oldPrice: item.oldPrice,
          newPrice: item.newPrice,
          availability: item.availability
        }));
        setProducts(normalized);
      })
      .catch(err => console.error('Ошибка загрузки:', err));
  }, [filters]);

  return (
    <div className="category-page">
      <div className="filters-panel">
        <Filters category="Ноутбуки" filters={filters} onFilterChange={handleFilterChange} />
      </div>
      <div className="category-catalog">
        <h1>Каталог ноутбуков</h1>
        <div className="product-grid">
          {products.map(p => (
            <ProductCard
              key={p.productId}
              id={p.productId}
              img={p.images?.[0]?.imageUrl || '/img/placeholder.png'}
              model={p.model}
              oldPrice={p.oldPrice}
              newPrice={p.newPrice}
              availability={p.availability}
              discount={p.oldPrice > p.newPrice ? Math.round((1 - p.newPrice / p.oldPrice) * 100) : 0}
            />
          ))}
        </div>
      </div>
    </div>
  );
};

export default Laptops;
