import axios from "axios";

const API_BASE_URL = "http://localhost:5085/api";

export const getProducts = async () => {
  try {
    const response = await axios.get(`${API_BASE_URL}/products`);
    return response.data;
  } catch (error) {
    console.error("Ошибка при загрузке товаров:", error);
    return [];
  }
};

export const getProductById = async (id) => {
  try {
    const response = await axios.get(`${API_BASE_URL}/products/${id}`);
    return response.data;
  } catch (error) {
    console.error("Ошибка при загрузке товара:", error);
    return null;
  }
};
// 📦 Получить товары по категории и фильтрам
export const getProductsByCategory = async (category, filters = {}) => {
  try {
    const params = new URLSearchParams();

    Object.entries(filters).forEach(([key, value]) => {
      if (value) params.append(key, value);
    });

    const response = await axios.get(`${API_BASE_URL}/products/category/${category}?${params}`);
    return response.data;
  } catch (error) {
    console.error(`Ошибка при загрузке товаров категории ${category}:`, error);
    return [];
  }
};


