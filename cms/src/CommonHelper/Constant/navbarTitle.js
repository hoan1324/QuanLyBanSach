import { Link } from "react-router";
import { FaHome } from "react-icons/fa";
import { MdWork } from "react-icons/md";
import { FaPersonChalkboard } from "react-icons/fa6";
import { TbCategory } from "react-icons/tb";

const navbarTitle = [
  {
    key: "navigation",
    label: "Điều hướng",
    type: "group",
    children: [
      {
        key: "/Home",
        icon: <FaHome />,
        label: <Link to="/Home">Trang chủ</Link>,
      },
    ],
  },
  {
    key: "service",
    label: "Dịch vụ",
    type: "group",
    children: [
      {
        key: "/Job",
        icon: <MdWork />,
        label: <Link to="/Job">Công việc</Link>,
        permission: "Job-GetListAsync",
      },
      {
        key: "/Staff",
        icon: <FaPersonChalkboard />,
        label: <Link to="/Staff">Nhân viên</Link>,
        permission: "Staff-GetListAsync",
      },
      {
        key: "/Category",
        icon: <TbCategory />,
        label: <Link to="/Category">Danh mục</Link>,
        permission: "Category-GetListAsync",
      },
    ],
  },

  {
    key: "user",
    label: "Người dùng",
    type: "group",
    // children: [

    // ]
  },
  {
    key: "title3",
    label: "Cấu hình",
    type: "group",
    // children: [

    // ]
  },
];
export { navbarTitle };
