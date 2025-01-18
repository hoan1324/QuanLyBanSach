import { Space } from "antd";
import { BiCommentDetail } from "react-icons/bi";
import { MdDeleteForever } from "react-icons/md";
import { FaRegEdit } from "react-icons/fa";

import {Tooltip } from "antd"
const actionColumn=({handleEdit})=>{
    return{
        title: "Chức năng",
        dataIndex: "action",
        key: "action",
        align: 'center',
        width:170,
        render: (_, record) => (
            <Space size="middle">
                <Tooltip title="Xem chi tiết">
                    <BiCommentDetail
                        style={{ color: 'blue', cursor: 'pointer',fontSize:'20px' }}
                    />
                </Tooltip>
                <Tooltip title="Chỉnh sửa">
                    <FaRegEdit
                        style={{ color: 'orange', cursor: 'pointer' ,fontSize:'20px'}}
                        onClick={() => handleEdit(record.key)}                    />
                </Tooltip>
                <Tooltip title="Xóa">
                    <MdDeleteForever
                        style={{ color: 'red', cursor: 'pointer',fontSize:'20px' }}
                        // onClick={() => onDelete(record)}
                    />
                </Tooltip>
            </Space>
        ),
    }
}

const columnNameJob=({handleEdit})=>{

    return  [
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

        },
        {
            title: "Mức lương tối đa",
            dataIndex: "salaryMax",
            key: "salaryMax",
            align: 'center',

        },
        {
            title: "Mô tả công việc",
            dataIndex: "description",
            key: "description",
            align: 'center',

        },
        actionColumn({handleEdit}),

    ];
}

    

   

export { columnNameJob }
