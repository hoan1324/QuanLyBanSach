import Header from "../Components/Header";
import Footer from "../Components/Footer";
import LeftNavBar from "../Components/LeftNavBar"
import styles from "./DefaultLayouStyle.module.scss"
import classNames from "classnames/bind";

function DefaultLayout({ children }) {
    const cx = classNames.bind(styles)
    return (
        <div className={cx("body")} >
            <div className={cx("body-content","d-flex")} >
                <LeftNavBar />
                <div className={cx("content")}>
                    <Header />
                    <div className={cx("content-detail")}>{children}</div>
                    <Footer />
                </div>
            </div>
        </div>
    );
}

export default DefaultLayout;