import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useUserDispatch, useUserSelector } from "../../hooks/userHooks";
import { IUserCreate } from "../../models/user/IUserCreate";
import { createUser, getAllUsers } from "../../store/reducers/user/userActionCreator";
import { useLoginFormData } from "./loginForm";

export const useRegisterFunc = () => {
    const navigation = useNavigate();
    const dispatch = useUserDispatch();
    const {
        username,
        handle_UserName_Change,
        age,
        handle_Age_Change,
        login,
        handle_Login_Change,
        password,
        handle_Password_Change } = useLoginFormData();
    const users = useUserSelector(state => state.UserSlice.Users);
    useEffect(() => {
        dispatch(getAllUsers());
    }, [])
    const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        const user: IUserCreate = {
            username: username,
            age: age,
            isOnline: false,
            login: login,
            password: password,
            isAdmin: false
        }
        const existingUser = users.find((user) => user.username === username || user.login === login || user.password === password);
        if (!existingUser) {
            dispatch(createUser(user));
            navigation(`/`);
        }
        else {
            alert('Username/Login/Password - already exist in our DB');
        }
    }

    return {
        navigation, dispatch, username, handle_UserName_Change, age, handle_Age_Change,
        login, handle_Login_Change, password, handle_Password_Change, handleSubmit
    }
}
