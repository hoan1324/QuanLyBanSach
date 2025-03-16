import { Tag, Image } from "antd";

import actionColumn from "./actionColumn";
import { formatDateVn } from "../../CommonHelper/utils/helper/dateHelper";
import { formatMoneyVn } from "../../CommonHelper/utils/helper/moneyHelper";
import services from "../../boot/services";
import EntityName from "../Common/entityName";
import UseStatusMixin from "../../CommonHelper/utils/mixins/status";
import { urlApi } from "../../CommonHelper/utils/helper/urlApiFile";
import { commonColumn } from "../../CommonHelper/Constant/commonColumn";
const statusBadge = (status, id) => {
    const result = status.find(item => item.id === id);
    return result ? result.name : ""; // Trả về giá trị mặc định nếu không tìm thấy
};

const statusStyle = (status, id) => {
    const result = status.find(item => item.id === id);
    return result ? result.color : ""; // Trả về giá trị mặc định nếu không tìm thấy
};

const staffColumn = ({ handleEdit, handleDelete, handleDetail }) => {
    return [
        ...commonColumn,
        {
            title: "Tên nhân viên",
            dataIndex: "name",
            key: "name",
            align: "center",
        },
        {
            title: "Ngày sinh",
            dataIndex: "dateOfBirth",
            key: "dateOfBirth",
            align: "center",
            render: (date) => formatDateVn(date)
        },
        {
            title: "Mức lương",
            dataIndex: "salary",
            key: "salary",
            align: "center",
            render: (salary) => formatMoneyVn(salary),
        },
        {
            title: "Địa chỉ",
            dataIndex: "address",
            key: "address",
            align: "center",
        },
        {
            title: "Số điện thoại",
            dataIndex: "phoneNumber",
            key: "phoneNumber",
            align: "center",
        },
        {
            title: "Email",
            dataIndex: "email",
            key: "email",
            align: "center",
        },
        {
            title: "Ngày bắt đầu",
            dataIndex: "startDate",
            key: "startDate",
            align: "center",
            render: (date) => formatDateVn(date)

        },
        {
            title: "Ngày kết thúc",
            dataIndex: "endDate",
            key: "endDate",
            align: "center",
            render: (date) => formatDateVn(date)

        },
        {
            title: "Giới tính",
            dataIndex: "gender",
            key: "gender",
            align: "center",
            render: (_, record) => (
                <Tag color={statusStyle(UseStatusMixin().gender, record.gender)}>{statusBadge(UseStatusMixin().gender, record.gender)}</Tag>
            ),
        },
        {
            title: "Trạng thái",
            dataIndex: "status",
            key: "status",
            align: "center",
            render: (_, record) => (
                <Tag color={statusStyle(UseStatusMixin().staffStatus, record.status)}>{statusBadge(UseStatusMixin().staffStatus, record.status)}</Tag>
            ),
        },
        {
            title: "Ảnh đại diện",
            dataIndex: "avatar",
            key: "avatar",
            align: "center",
            render: (url) => url ? <Image className="object-fit-cover" src={urlApi(url)} alt="Avatar" style={{ width: 50, height: 50, borderRadius: "50%" }} /> : "",
        },
        {
            title: "Công việc",
            dataIndex: "job",
            key: "job",
            align: "center",
            render: (_, record) => {

                return <EntityName nameProp={'jobName'} id={record.job} service={services.jobService} />
            }
        },
        actionColumn({ handleEdit, handleDelete, handleDetail, title: "nhân viên" }),
    ];
};
export default staffColumn