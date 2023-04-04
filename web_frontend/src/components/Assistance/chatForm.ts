import { useState } from "react";

export const useChatFormData = () => {
    const [message, setMessage] = useState('');
    const handle_Message_Change = (event: React.ChangeEvent<HTMLInputElement>) => {
        setMessage(event.target.value);
    }

    return {
        message, handle_Message_Change
    }
}
