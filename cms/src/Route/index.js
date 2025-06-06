import Home from "../Pages/Home";
import Job from "../Pages/Job";
import Staff from "../Pages/Staff";
import Login from "../Pages/Login";
import Category from "../Pages/Category";

const publicRoute = [{ path: "/", element: Login, layout: null }];
const privateRouter = [
  { path: "/Home", element: Home, isPrivate: true },
  { path: "/Job", element: Job, isPrivate: true },
  { path: "/Staff", element: Staff, isPrivate: true },
  { path: "/Category", element: Category, isPrivate: true },
];
export { publicRoute, privateRouter };
