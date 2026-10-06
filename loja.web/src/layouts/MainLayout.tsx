import { Outlet } from "react-router-dom";

import Navbar from "../components/Navbar";

function MainLayout() {
  return (
    <div>

      <Navbar />

      <hr />

      <Outlet />

    </div>
  );
}

export default MainLayout;