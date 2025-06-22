import axios from 'axios';
import { getProductById, getProducts, getProductsByCategory } from './api';

// Мокаем axios
jest.mock('axios');

describe('API Tests', () => {
    beforeEach(() => {
        // Очищаем все моки перед каждым тестом
        jest.clearAllMocks();
    });

    test('getProducts успешно получает список товаров', async () => {
        const mockProducts = [
            { id: 1, name: 'Product 1' },
            { id: 2, name: 'Product 2' }
        ];

        axios.get.mockResolvedValueOnce({ data: mockProducts });

        const result = await getProducts();
        expect(result).toEqual(mockProducts);
        expect(axios.get).toHaveBeenCalledWith('http://localhost:5085/api/products');
    });

    test('getProducts обрабатывает ошибку', async () => {
        axios.get.mockRejectedValueOnce(new Error('Network error'));

        const result = await getProducts();
        expect(result).toEqual([]);
    });

    test('getProductById успешно получает товар по ID', async () => {
        const mockProduct = { id: 1, name: 'Product 1' };

        axios.get.mockResolvedValueOnce({ data: mockProduct });

        const result = await getProductById(1);
        expect(result).toEqual(mockProduct);
        expect(axios.get).toHaveBeenCalledWith('http://localhost:5085/api/products/1');
    });

    test('getProductsByCategory успешно получает товары по категории', async () => {
        const mockProducts = [
            { id: 1, name: 'Product 1', category: 'electronics' },
            { id: 2, name: 'Product 2', category: 'electronics' }
        ];

        const filters = { minPrice: 100, maxPrice: 1000 };

        axios.get.mockResolvedValueOnce({ data: mockProducts });

        const result = await getProductsByCategory('electronics', filters);
        expect(result).toEqual(mockProducts);
        expect(axios.get).toHaveBeenCalledWith(
            'http://localhost:5085/api/products/category/electronics?minPrice=100&maxPrice=1000'
        );
    });
});
