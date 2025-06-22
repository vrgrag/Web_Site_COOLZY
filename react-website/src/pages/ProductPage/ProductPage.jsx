import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import "./ProductPageStyles.css";

const ProductPage = () => {
  const { productId } = useParams();
  const [product, setProduct] = useState(null);
  const [reviews, setReviews] = useState([]);
  const [comment, setComment] = useState("");
  const [rating, setRating] = useState(5); // новая переменная оценки

  useEffect(() => {
    fetch(`http://localhost:5085/api/products/${productId}`)
      .then((res) => res.json())
      .then(setProduct)
      .catch(() => setProduct(null));

    fetch(`http://localhost:5085/api/reviews/${productId}`)
      .then(async (res) => (res.ok ? await res.json() : []))
      .then(setReviews)
      .catch(() => setReviews([]));
  }, [productId]);

  const handleAddToCart = async () => {
    const user = JSON.parse(localStorage.getItem("user"));
    if (!user?.userId || !product?.productId)
      return alert("Ошибка: не авторизован или нет товара");

    try {
      const response = await fetch("http://localhost:5085/api/cart/add", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
          userId: user.userId,
          productId: product.productId,
          quantity: 1,
        }),
      });

      if (response.ok) {
        alert("Товар добавлен в корзину");
      } else {
        const err = await response.text();
        console.error("Ошибка от сервера:", err);
        alert("Не удалось добавить в корзину");
      }
    } catch (error) {
      console.error("Ошибка корзины:", error);
    }
  };

  const handleReviewSubmit = async (e) => {
    e.preventDefault();
    const user = JSON.parse(localStorage.getItem("user"));
    if (!user?.username || !user?.userId)
      return alert("Войдите в аккаунт");

    const review = {
      productId: parseInt(productId),
      userId: user.userId,
      userName: user.username,
      rating,
      comment,
    };

    try {
      console.log("Review being sent:", review);

      await fetch("http://localhost:5085/api/reviews/add", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(review),
      });

      setComment("");
      setRating(5);
      const res = await fetch(`http://localhost:5085/api/reviews/${productId}`);
      setReviews(await res.json());
    } catch (err) {
      console.error("Ошибка отзыва", err);
    }
  };

  if (!product)
    return <div className="error">Загрузка...</div>;

  return (
    <div className="product-page-container">
      <div className="product-main-content">
        <div className="product-left-column">
          <div className="product-image-wrapper">
            <img
              src={product.images?.[0]?.imageUrl || "/img/placeholder.png"}
              alt={product.model}
              className="product-main-image"
            />
            <div className="availability-badge in-stock">
              {product.availability || "В наличии"}
            </div>
          </div>
        </div>

        <div className="product-right-column">
          <h1 className="product-title">{product.model}</h1>
          <div className="price-wrapper">
            {product.oldPrice > product.newPrice && (
              <div className="old-price">{product.oldPrice.toLocaleString()} BYN</div>
            )}
            <div className="new-price">{product.newPrice.toLocaleString()} BYN</div>
          </div>
          <button className="add-to-cart-btn" onClick={handleAddToCart}>
            Добавить в корзину
          </button>

          <div className="product-specs">
            <h3>Характеристики</h3>
            <div className="specs-grid">
              {product.ram && (
                <div className="spec-item">
                  <span className="spec-title">ОЗУ</span>
                  <span>{product.ram}</span>
                </div>
              )}
              {product.storage && (
                <div className="spec-item">
                  <span className="spec-title">Память</span>
                  <span>{product.storage}</span>
                </div>
              )}
              <div className="spec-item">
                <span className="spec-title">Бренд</span>
                <span>{product.brand}</span>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div className="product-reviews">
        <h3>Отзывы</h3>
        <form onSubmit={handleReviewSubmit} className="review-form">
          <label>Оценка:</label>
          <select
            value={rating}
            onChange={(e) => setRating(parseInt(e.target.value))}
            required
          >
            <option value={5}>5 ⭐</option>
            <option value={4}>4 ⭐</option>
            <option value={3}>3 ⭐</option>
            <option value={2}>2 ⭐</option>
            <option value={1}>1 ⭐</option>
          </select>
          <textarea
            value={comment}
            onChange={(e) => setComment(e.target.value)}
            placeholder="Оставьте ваш отзыв"
            required
            rows="4"
          />
          <button type="submit" className="add-to-cart-btn">Отправить отзыв</button>
        </form>

        {reviews.length === 0 ? (
          <p>Отзывов пока нет</p>
        ) : (
          <ul className="review-list">
            {reviews.map((r) => (
              <li key={r.id} className="review-item">
                <div className="review-header">
                  <strong>{r.userName}</strong>
                  <span className="review-rating">{"⭐".repeat(r.rating)}</span>
                </div>
                <div className="review-date">{new Date(r.createdAt).toLocaleDateString()}</div>
                <div>{r.comment}</div>
              </li>
            ))}
          </ul>
        )}
      </div>
    </div>
  );
};

export default ProductPage;
