import vnConst from "../../../i18vn/vi-VN"
const defaultFolder = [vnConst.document, vnConst.file, vnConst.image]

const checkDefaultFolder = (text) => defaultFolder.includes(text)

export default checkDefaultFolder
