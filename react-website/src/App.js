import React from 'react';
import { Routes, Route } from 'react-router-dom';
import Header from './Components/Header/Header';
import Footer from './Components/Footer/Footer';
import Home from './pages/Home/Home';
import Smartphones from './pages/Catalog/Smartphones';
import Laptops from './pages/Catalog/Laptops';
import Tablets from './pages/Catalog/Tablets';
import Televisions from './pages/Catalog/Televisions';
import Speakers from './pages/Catalog/Speakers';
import ProductPage from './pages/ProductPage/ProductPage';
import Catalog from './pages/Catalog/Catalog';
import Cart from "./Components/Cart/Cart";
import Checkout from "./Components/Checkout/Checkout";
import OrderSuccess from './Components/Order_sucsess/OrderSuccess';
import ProfilePage from './pages/Auth/ProfilePage';
import ForgotPassword from './pages/Auth/ForgotPassword';
import LoginForm from './pages/Auth/LoginForm';
import RegisterForm from './pages/Auth/RegisterForm';
import ResetPassword from './pages/Auth/ResetPassword';
import PrivacyPolicy from './pages/PrivacyPolicy/PrivacyPolicy';
import AboutUs from './pages/AboutUs/AboutUs';
import ReturnObmen from "./pages/ReturnObmen/ReturnObmen";
import DeliveryPay from "./pages/DeliveryPay/DeliveryPay";
import BonusProgram from "./pages/BonusProgram/BonusProgram";
import QuestionsAnswers from "./pages/QuestionsAnswers/QuestionsAnswers";
import NotFound from './Components/NotFound/NotFound';

import ComparePage from './pages/ComparePage/ComparePage';
import PrivateRoute from './Components/PrivateRoute/PrivateRoute';
import AdminRoute from './Components/AdminRoute/AdminRoute';
import AdminLayout from './layouts/AdminLayout';

import "./App.css";

function App() {
  return (
    <div className="App">
      <Routes>
        {/* Админка — без хедера и футера */}
        <Route path="/admin/*" element={
          <AdminRoute>
            <AdminLayout />
          </AdminRoute>
        } />

        {/* Обычные страницы сайта с хедером и футером */}
        <Route path="*" element={
          <>
            <Header />
            <main className="main-content">
              <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/category" element={<Catalog />} />
                <Route path="/category/Смартфоны" element={<Smartphones />} />
                <Route path="/category/Ноутбуки" element={<Laptops />} />
                <Route path="/category/Планшеты" element={<Tablets />} />
                <Route path="/category/Телевизоры" element={<Televisions />} />
                <Route path="/category/Колонки" element={<Speakers />} />
                <Route path="/products/:productId" element={<ProductPage />} />
                <Route path="/cart" element={<PrivateRoute><Cart /></PrivateRoute>} />
                <Route path="/checkout" element={<PrivateRoute><Checkout /></PrivateRoute>} />
                <Route path="/order-success" element={<OrderSuccess />} />
                <Route path="/profile" element={<PrivateRoute><ProfilePage /></PrivateRoute>} />
                <Route path="/forgot-password" element={<ForgotPassword />} />
                <Route path="/login" element={<LoginForm />} />
                <Route path="/register" element={<RegisterForm />} />
                <Route path="/reset-password" element={<ResetPassword />} />
                <Route path="/privacy-policy" element={<PrivacyPolicy />} />
                <Route path="/about-us" element={<AboutUs />} />
                <Route path="/return-obmen" element={<ReturnObmen />} />
                <Route path="/delivery-pay-answ" element={<DeliveryPay />} />
                <Route path="/bonus-program" element={<BonusProgram />} />
                <Route path="/ques-answ" element={<QuestionsAnswers />} />
                <Route path="*" element={<NotFound />} />
                <Route path="/compare" element={<ComparePage />} />
              </Routes>
            </main>
            <Footer />
          </>
        } />
      </Routes>
    </div>
  );
}

export default App;
