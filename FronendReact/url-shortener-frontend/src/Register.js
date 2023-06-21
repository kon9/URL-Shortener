import React, { useState } from "react";
import axios from "axios";

function Register() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const register = async () => {
    try {
      await axios.post("https://localhost:7041/api/user/register", { email, password });
    } catch (err) {
      console.error(err);
    }
  };

  return (
    <div className="form">
      <h1>Register</h1>
      <input type="email" value={email} onChange={(e) => setEmail(e.target.value)} placeholder="Email" />
      <input type="password" value={password} onChange={(e) => setPassword(e.target.value)} placeholder="Password" />
      <button onClick={register}>Register</button>
    </div>
  );
}

export default Register;