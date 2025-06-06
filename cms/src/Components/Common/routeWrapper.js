import DefaultLayout from "../Layout/DefaultLayout";
import { Fragment } from "react";
import { Navigate, Outlet } from "react-router-dom";
import useAuthStore from "../../store/authStore";
import Cookies from "js-cookie";
import constantType from "../../CommonHelper/Constant/constantType";

const RouteWrapper = ({ route }) => {
  const { getAccessToken } = useAuthStore();

  // Nếu là private route và chưa đăng nhập -> chuyển hướng đến trang login
  if (route.isPrivate) {
    if (!getAccessToken() && !Cookies.get(constantType.accessToken)) {
      return <Navigate to="/" />;
    }
  }

  let Layout = route.layout
    ? route.layout
    : route.layout === null
    ? Fragment
    : DefaultLayout;

  return (
    <Layout>
      <route.element />
    </Layout>
  );
};

export default RouteWrapper;
