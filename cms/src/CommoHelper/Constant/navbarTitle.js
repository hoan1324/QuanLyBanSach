import { Link } from "react-router";
import { FaHome } from "react-icons/fa";
import { MdWork } from "react-icons/md";

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


