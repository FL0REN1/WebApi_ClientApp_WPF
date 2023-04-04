import { useEffect } from "react";
import { getAllUsers } from "../../store/reducers/user/userActionCreator";
import { useLoginFunc } from "../Assistance/LoginFunc";

export default function Login() {
    const { navigate, dispatch, login, password, handle_Login_Change, handle_Password_Change, handleSubmit } = useLoginFunc();
    useEffect(() => {
        dispatch(getAllUsers())
    }, [])
    return (
        <div className="login-box">
            <h2>Login</h2>
            <form onSubmit={handleSubmit}>
                <div className="user-box">
                    <input value={login} onChange={handle_Login_Change} type="text" name="login" required={true} />
                    <label>Login</label>
                </div>
                <div className="user-box">
                    <input value={password} onChange={handle_Password_Change} type="password" name="password" required={true} />
                    <label>Password</label>
                </div>
                <button type="submit" className="submit-btn reset-btn">
                    <span></span>
                    <span></span>
                    <span></span>
                    <span></span>
                    Submit
                </button>
                <a className="register-btn" onClick={() => navigate('/register')}>
                    <span></span>
                    <span></span>
                    <span></span>
                    <span></span>
                    Register
                </a>
            </form>
        </div>
    );
}