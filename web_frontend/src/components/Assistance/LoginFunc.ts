import { useNavigate } from "react-router-dom";
import { useUserDispatch, useUserSelector } from "../../hooks/userHooks";
import { IUserLogin } from "../../models/user/IUserLogin";
import { checkLoginUser } from "../../store/reducers/user/userActionCreator";
import { useLoginFormData } from "./loginForm";

export const useLoginFunc = () => {
    const navigate = useNavigate();
    const dispatch = useUserDispatch();
    const users = useUserSelector(state => state.UserSlice.Users);
    const {
        login,
        handle_Login_Change,
        password,
        handle_Password_Change } = useLoginFormData();
    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        const userModel = users.find(user => user.login == login && user.password == password);
        const user: IUserLogin = {
            login: login,
            password: password
        }
        dispatch(checkLoginUser(user)).then((response) => {
            if (response.payload != 'Request failed with status code 404' && response.payload != 'Network Error') {
                navigate(`/chat/${userModel?.id}`);
            } else {
                alert('Login/Password - have not exist in our DB');
            }
        });
    }

    return {
        navigate, dispatch, login, password, handle_Login_Change, handle_Password_Change, handleSubmit
    }
}
