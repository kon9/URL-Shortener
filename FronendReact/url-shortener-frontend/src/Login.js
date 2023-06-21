import React, { useState } from "react";
import axios from "axios";
import { useNavigate } from 'react-router-dom';

function Login({ onLogin }) {
  const navigate = useNavigate();
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const login = async () => {
    try {
      const response = await axios.post("https://localhost:7041/api/user/login", { email, password });
      onLogin(response.data.token);
      navigate("/urlShortening"); // redirects after successful login
    } catch (err) {
      console.error(err);
    }
  };

  return (
    <div className="form">
      <h1>Login</h1>
      <input type="email" value={email} onChange={(e) => setEmail(e.target.value)} placeholder="Email" />
      <input type="password" value={password} onChange={(e) => setPassword(e.target.value)} placeholder="Password" />
      <button onClick={login}>Login</button>
    </div>
  );
}

export default Login;