import { Descriptions } from "antd";
import { formatMoneyVn } from "../../CommonHelper/utils/helper/moneyHelper";
import dayjs from "dayjs";

function CategoryDetail({ data }) {
  return (
    <div
      style={{
        padding: 16,
        background: "#fafcff",
        borderRadius: 12,
        textAlign: "center",
      }}
    >
      <Descriptions
        bordered
        column={1}
        size="middle"
        labelStyle={{
          width: 180,
          fontWeight: 500,
          background: "#f5f7fa",
          textAlign: "left", // label căn trái
        }}
        contentStyle={{
          fontSize: 16,
          background: "#fff",
          textAlign: "center", // value căn giữa
        }}
      >
        <Descriptions.Item label="Tên danh mục">{data.name}</Descriptions.Item>

        <Descriptions.Item label="Mô tả danh mục">
          {data?.description}
        </Descriptions.Item>

        <Descriptions.Item label="Ngày tạo">
          {data.createdDate
            ? dayjs(data.createdDate).format("DD/MM/YYYY HH:mm")
            : ""}
        </Descriptions.Item>
        <Descriptions.Item label="Người tạo">
          {data.createdByUserName || ""}
        </Descriptions.Item>
        <Descriptions.Item label="Ngày sửa">
          {data.modifiedDate
            ? dayjs(data.modifiedDate).format("DD/MM/YYYY HH:mm")
            : ""}
        </Descriptions.Item>
        <Descriptions.Item label="Người sửa">
          {data.modifiedByUserName || ""}
        </Descriptions.Item>
      </Descriptions>
    </div>
  );
}

export default CategoryDetail;
