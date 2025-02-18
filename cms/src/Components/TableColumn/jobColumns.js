import actionColumn from "./actionColumn";
import { formatMoneyVn } from "../../CommonHelper/utils/helper/moneyHelper";
const jobColumn = ({ handleEdit, handleDelete, handleDetail }) => {

    return [
        {
            title: "Tên công việc",
            dataIndex: "name",
            key: "name",
            align: 'center',

        },
        {
            title: "Mức lương tối thiểu",
            dataIndex: "salaryMin",
            key: "salaryMin",
            align: 'center',
            render: (salary) => formatMoneyVn(salary),

        },
        {
            title: "Mức lương tối đa",
            dataIndex: "salaryMax",
            key: "salaryMax",
            align: 'center',
            render: (salary) => formatMoneyVn(salary),

        },
        {
            title: "Mô tả công việc",
            dataIndex: "description",
            key: "description",
            align: 'center',

        },

        actionColumn({ handleEdit, handleDelete, handleDetail, title: "công việc" }),

    ];
}
export default jobColumn