import './App.css';
import React from 'react';
import linePackage from './line-package.json';

function App() {
  const [data, setData] = React.useState(null);

  React.useEffect(() => {
    const url = process.env.REACT_APP_BACKEND_URL;
    async function fetchData(){
      try{
        const res = await fetch(`${url}/api/v1/line/packages`);
        const data = await res.json();
        setData(data);
      }catch(err){
        setData(linePackage);
      }
    }

    fetchData();
  }, []);

  return (
    <div className="App">
      <div>
        <pre>
          {data && JSON.stringify(data, null, 2)}
        </pre>
      </div>
    </div>
  );
}

export default App;
