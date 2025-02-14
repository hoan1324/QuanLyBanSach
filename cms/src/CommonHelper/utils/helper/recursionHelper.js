import services from "../../../boot/services"
import { CiFolderOn } from "react-icons/ci";
import vnConst from "../../../i18vn/vi-VN";
import UseStatusMixin from "../mixins/status";
import { data } from "react-router";

export const childrenAttachmentFolder = (data, parentId) => {
    return data?.filter(item => item.parentId == parentId && item.status == 0)
}
export const subsequentRankList = (data, parentId) => {
    if (parentId === null) {
        return childrenAttachmentFolder(data, parentId)
    }
    return childrenAttachmentFolder(data,parentId)

}
export const attachmentFolderRecursion = (data, parentId) => {
    const attachmentFolderParent = childrenAttachmentFolder(data, parentId)
    const attachmentFolderRemaining = data?.filter(item => item.parentId != parentId && item.status == 0)
    return attachmentFolderParent?.map((item) => {
        const children = attachmentFolderRemaining?.filter(child => child.parentId === item.id);

        return {
            key: item.id,
            label: item.name,
            icon: <CiFolderOn />,
            ...(children?.length ? { children: attachmentFolderRecursion(attachmentFolderRemaining, item.id) } : {}) // Chỉ thêm children nếu có dữ liệu
        }
    })
}