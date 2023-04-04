import { useState } from "react";

export const useLoginFormData = () => {
    const [username, setUsername] = useState('');
    const [age, setAge] = useState(18);
    const [login, setLogin] = useState('');
    const [password, setPassword] = useState('');
    const handle_UserName_Change = (event: React.ChangeEvent<HTMLInputElement>) => {
        setUsername(event.target.value);
    }
    const handle_Age_Change = (event: React.ChangeEvent<HTMLInputElement>) => {
        const age = parseInt(event.target.value);
        setAge(age);
    }
    const handle_Login_Change = (event: React.ChangeEvent<HTMLInputElement>) => {
        setLogin(event.target.value);
    }
    const handle_Password_Change = (event: React.ChangeEvent<HTMLInputElement>) => {
        setPassword(event.target.value);
    }

    return {
        username,
        handle_UserName_Change,
        age,
        handle_Age_Change,
        login,
        handle_Login_Change,
        password,
        handle_Password_Change
    }
}