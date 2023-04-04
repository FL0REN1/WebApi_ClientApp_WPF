import { useEffect } from "react";
import { getAllUsers } from "../../store/reducers/user/userActionCreator";
import { useRegisterFunc } from "../Assistance/RegisterFunc";

export default function Register() {
    const { navigation, dispatch, username, handle_UserName_Change, age, handle_Age_Change,
        login, handle_Login_Change, password, handle_Password_Change, handleSubmit } = useRegisterFunc();
    useEffect(() => {
        dispatch(getAllUsers());
    }, [])
    return (
        <div className="login-box">
            <h2>Register</h2>
            <form onSubmit={handleSubmit}>
                <div className="user-box">
                    <input value={username} onChange={handle_UserName_Change} type="text" name="username" required={true} />
                    <label>Username</label>
                </div>
                <div className="user-box">
                    <input value={age} onChange={handle_Age_Change} type="number" name="age" min={18} max={120} required={true} />
                    <label>Age</label>
                </div>
                <div className="user-box">
                    <input value={login} onChange={handle_Login_Change} type="email" name="login" required={true} />
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
                <a className="register-btn" onClick={() => navigation('/')}>
                    <span></span>
                    <span></span>
                    <span></span>
                    <span></span>
                    Login
                </a>
            </form>
        </div>
    );
}