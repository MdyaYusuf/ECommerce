import { createBrowserRouter, Navigate } from "react-router";
import App from "../layouts/App";
import HomePage from "../features/HomePage";
import AboutPage from "../features/AboutPage";
import ContactPage from "../features/ContactPage";
import ShoppingCartPage from "../features/cart/ShoppingCartPage";
import ProductDetailsPage from "../features/product/ProductDetails";
import ServerError from "../errors/ServerError";
import NotFound from "../errors/NotFound";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      { path: "", element: <HomePage /> },
      { path: "about", element: <AboutPage /> },
      { path: "contact", element: <ContactPage /> },
      { path: "cart", element: <ShoppingCartPage /> },
      { path: "/:id", element: <ProductDetailsPage /> },
      { path: "server-error", element: <ServerError /> },
      { path: "not-found", element: <NotFound /> },
      { path: "*", element: <Navigate to="/not-found" /> }
    ]
  }
])