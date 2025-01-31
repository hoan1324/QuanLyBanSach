import { Link } from "react-router";
import { FaHome } from "react-icons/fa";
import { MdWork } from "react-icons/md";
import { FaPersonChalkboard } from "react-icons/fa6";


const navbarTitle = [
    {
        key: "navigation",
        label: "Điều hướng",
        type: "group",
        children: [
            {
                key: "/",
                icon: <FaHome />,
                label: (
                    <Link to="/">
                        Trang chủ
                    </Link>
                )
            }
        ]

    },
    {
        key: "service",
        label: "Dịch vụ",
        type: "group",
        children: [
            {
                key: "/Job",
                icon: <MdWork />,
                label: (
                    <Link to="/Job">
                        Công việc
                    </Link>
                )
            },
            {
                key: "/Staff",
                icon: <FaPersonChalkboard />,
                label: (
                    <Link to="/Staff">
                        Nhân viên
                    </Link>
                )
            }
        ]

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
]
export { navbarTitle }


