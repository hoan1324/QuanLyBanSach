import { Modal, Form, Input, Button, message } from "antd";
import { Link, useNavigate, useLocation } from "react-router";
import { useEffect, useMemo } from "react";
import useAuthStore from "../../store/authStore";
import services from "../../../src/boot/services";
import constantType from "../../CommonHelper/Constant/constantType";
import Cookies from "js-cookie";
import { actionDiffirent } from "../../CommonHelper/utils/helper/communicateApi";

function Login() {

    const navigate = useNavigate();
    const location = useLocation().pathname
    const [form] = Form.useForm();
    const store = useAuthStore();
    const currentUser = useMemo(() => store.getCurrentUser(), [store]);
    const accessToken = Cookies.get(constantType.accessToken);
    //console.log(navigate);

    console.log("Component Login mounted");



    const onFinish = async (values) => {

        try {
            const service = services.authService;

            const response = await actionDiffirent(service, "login", [values]);
            console.log(response);

            if (response.isSuccess) {
                message.success(response.messsage);
                store.setAccessToken(response.data.accessToken);
                navigate("/Home"); // ✅ Dùng useNavigate() thay vì return <Navigate />
            }
            else {
                message.error(response.message);

            }

        } catch (error) {
            message.error("Có 1 vài lỗi xảy ra trong hệ thống")
            console.log(error);
        }
    }

    useEffect(() => {
        if (currentUser?.id || accessToken) {
            if (location === "/") {
                navigate("/Home");
            }
        }
    }, [currentUser, accessToken, location, navigate]); // ✅ Giảm re-render không cần thiết
    return (
        <Modal
            title={
                < div>
                    <h2 className="d-flex justify-content-center my-3">Đăng nhập</h2>
                    <div className="d-flex justify-content-center mb-3">
                        <img width="60" src="/logo192.png" alt="Logo" />
                    </div>
                </div>
            }
            closable={false}
            open={true}
            width={600}
            centered
            footer={null} // Sử dụng điều kiện để kiểm soát footer
        >
            <div className="container mt-3" style={{ height: '50vh' }}>
                <Form onFinish={onFinish} layout="vertical" form={form}>
                    <Form.Item label="UserName" name="username" rules={[{ required: true, message: 'Vui lòng nhập tên đăng nhập!' },]}>
                        <Input placeholder="Nhập tên đăng nhập..." />
                    </Form.Item>
                    <Form.Item className="mb-1" label="Mật khẩu" name="password" rules={[{ required: true, message: 'Vui lòng nhập mật khẩu!' },]}>
                        <Input.Password placeholder="Nhập mật khẩu..." />
                    </Form.Item>
                    <div className="d-flex justify-content-end">
                        <Link to="./" >Quên mật khẩu</Link>
                    </div>
                    <Form.Item>
                        <Button type="primary" htmlType="submit" className="mt-3 w-100">
                            Đăng nhập
                        </Button>
                    </Form.Item>
                </Form>

            </div>
        </Modal >
    );
}
export default Login;