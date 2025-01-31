import { Space, Popconfirm, Tag } from "antd";
import { BiCommentDetail } from "react-icons/bi";
import { MdDeleteForever } from "react-icons/md";
import { FaRegEdit } from "react-icons/fa";
import { Tooltip } from "antd"
import UseStatusMixin from "../../CommonHelper/utils/mixins/status";
import services from "../../boot/services";
import { useState, useEffect,useCallback } from "react";

const statusBadge = (status, id) => {
    const result = status.find(item => item.id === id);
    return result ? result.name : ""; // Trả về giá trị mặc định nếu không tìm thấy
};

const statusStyle = (status, id) => {
    const result = status.find(item => item.id === id);
    return result ? result.color : ""; // Trả về giá trị mặc định nếu không tìm thấy
};

const findByID = async (service, id) => {
    try {
        const response = await service.getById(id)
        if (response.status === 500 || !response.isSuccess) {
            return null;
        }
        return response.data;
    }
    catch (error) {
        console.log("bị lỗi vào đây");
        
        console.log(error);
        return null

    }
}
const actionColumn = ({ handleEdit, handleDelete, handleDetail }) => {
    return {
        title: "Chức năng",
        dataIndex: "action",
        key: "action",
        align: 'center',
        width: 170,
        render: (_, record) => (
            <Space size="middle">
                <Tooltip title="Xem chi tiết">
                    <BiCommentDetail
                        style={{ color: 'blue', cursor: 'pointer', fontSize: '20px' }}
                        onClick={() => handleDetail(record.key)}
                    />
                </Tooltip>
                <Tooltip title="Chỉnh sửa">
                    <FaRegEdit
                        style={{ color: 'orange', cursor: 'pointer', fontSize: '20px' }}
                        onClick={() => handleEdit(record.key)} />
                </Tooltip>
                <Popconfirm
                    title="Xác nhận xóa công việc"
                    description="Bạn có chắc muốn xóa công việc này không?"
                    onConfirm={() => handleDelete(record.key)}
                    // onCancel={cancel}
                    okText="Xác nhận "
                    cancelText="Hủy"
                >
                    <Tooltip title="Xóa">
                        <MdDeleteForever
                            style={{ color: 'red', cursor: 'pointer', fontSize: '20px' }}
                        />
                    </Tooltip>
                </Popconfirm>
            </Space>
        ),
    }
}
const columnNameJob = ({ handleEdit, handleDelete, handleDetail }) => {

    return [
        {
            title: "Tên công việc",
            dataIndex: "jobName",
            key: "jobName",
            align: 'center',

        },
        {
            title: "Mức lương tối thiểu",
            dataIndex: "salaryMin",
            key: "salaryMin",
            align: 'center',
            render: (salary) => salary?.toLocaleString("vi-VN", { style: "currency", currency: "VND" }),

        },
        {
            title: "Mức lương tối đa",
            dataIndex: "salaryMax",
            key: "salaryMax",
            align: 'center',
            render: (salary) => salary?.toLocaleString("vi-VN", { style: "currency", currency: "VND" }),

        },
        {
            title: "Mô tả công việc",
            dataIndex: "description",
            key: "description",
            align: 'center',

        },

        actionColumn({ handleEdit, handleDelete, handleDetail }),

    ];
}
const JobName = ({jobId}) => {
    const [jobName, setJobName] = useState("");
   const fetchData = useCallback(async () => {
       
       const job = await findByID(services.jobService,jobId);
      
       if(job !=null){
        setJobName(job.jobName)
       }
       
      
     }, [jobId]);
   
       fetchData()


    return <>{jobName}</>;
};
const columnNameStaff = ({ handleEdit, handleDelete, handleDetail }) => {
    return [
        {
            title: "Tên nhân viên",
            dataIndex: "staffName",
            key: "staffName",
            align: "center",
        },
        {
            title: "Ngày sinh",
            dataIndex: "dateOfBirth",
            key: "dateOfBirth",
            align: "center",
            render: (date) => date ? new Date(date).toLocaleDateString("vi-VN") : ""
        },
        {
            title: "Mức lương",
            dataIndex: "salary",
            key: "salary",
            align: "center",
            render: (salary) => salary?.toLocaleString("vi-VN", { style: "currency", currency: "VND" }),
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
            render: (date) => date ? new Date(date).toLocaleDateString("vi-VN") : ""

        },
        {
            title: "Ngày kết thúc",
            dataIndex: "endDate",
            key: "endDate",
            align: "center",
            render: (date) => date ? new Date(date).toLocaleDateString("vi-VN") : ""

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
            render: (url) => url ? <img src={url} alt="Avatar" style={{ width: 50, height: 50, borderRadius: "50%" }} /> : "",
        },
        {
            title: "Công việc",
            dataIndex: "job",
            key: "job",
            align: "center",
            render: (_, record) => {

               return <JobName jobId={record.job} />
            }
        },
        actionColumn({ handleEdit, handleDelete, handleDetail }),
    ];
};

export { columnNameJob, columnNameStaff }
