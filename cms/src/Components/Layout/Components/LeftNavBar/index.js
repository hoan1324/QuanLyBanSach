import { Link } from "react-router"
import navBarConst from "../../../../CommoHelper/Constant/NavbarConst"

function LeftNavBar() {
    return (
        <ul>
            {navBarConst.map((content, index) => (               
                    <li key={index}>
                        <Link to={content.link}>{content.title}</Link>
                    </li>
            ))}
        </ul>
    )

}
export default LeftNavBar