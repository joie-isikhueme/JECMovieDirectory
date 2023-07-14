import { useState } from 'react'
import { BrowserRouter, Routes, Route } from "react-router-dom";
import MovieDirectory from './components/MovieDirectory';
import MovieDetails from './components/MovieDetails';

function App() {
  

  return (
    <div>
      <h3 className='text-xl text-pink-900 font-medium bg-zinc-100 p-4'>JEC MOVIE DIRECTORY</h3>
      <BrowserRouter>
        <Routes>
            <Route index element={<MovieDirectory />} />
            <Route path='/movie/:id' element={<MovieDetails />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
