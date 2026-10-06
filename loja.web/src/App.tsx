import {
  BrowserRouter,
  Routes,
  Route
} from "react-router-dom";
import MainLayout from "./layouts/MainLayout";
import HomePage from "./pages/HomePage";
import ProdutosPage from "./pages/ProdutosPage";

function App() {
  return (
    <BrowserRouter>
      <Routes>

        <Route
          element={<MainLayout />}
        >

          <Route
            path="/"
            element={<HomePage />}
          />

          <Route
            path="/produtos"
            element={<ProdutosPage />}
          />

        </Route>

      </Routes>
    </BrowserRouter>
  );
}

export default App;