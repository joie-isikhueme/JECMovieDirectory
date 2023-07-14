import { useEffect, useState } from 'react'
import { Link } from 'react-router-dom'

function MovieDirectory() {
    const [ page, setPage ] = useState(1)
    const [ movieTitle, setMovieTitle ] = useState("")
    const [ results, setResults ] = useState(null)
    const [ queries, setQueries ] = useState(null)

    const fetchMovie = (e) => {
      e.preventDefault()
        fetch(`${process.env.REACT_APP_BASE_URL}/api/Movies/search?query=${movieTitle}&page=${page}`)
          .then(response => {
            return response.json()
          })
          .then(data => {
            setResults(data)
          })
        }

        useEffect(() => {
          fetch(`${process.env.REACT_APP_BASE_URL}/api/Query`)
              .then(response => {
              return response.json()
              })
              .then(data => {
              setQueries(data.value)
              })
        }, []);
        

    return (
      <div className='flex border-gray-300 border rounded my-4 flex-col p-4 w-2/5 mx-auto'>
      <div className='mx-auto space-y-4'>
        <form onSubmit={fetchMovie}>
          <div className='space-y-4'>
            <div className='flex flex-col gap-2'>                                                    
          <label className='font-medium'>Movie Title</label>
            <input
              type="text"
              id="movieTitle"
              value={movieTitle}
              onChange={(event) => {
                setMovieTitle(event.target.value);
              }}
              className = 'border border-black rounded w-64 px-3 py-1'
            /></div>

            <div className='flex flex-col gap-2'>
            <label className='font-medium'>Page</label>
            <input
              type="number"
              id="page"
              value={page}
              onChange={(event) => {
                setPage(event.target.value);
              }}
              className = 'border border-black rounded w-64 px-3 py-1'
            />
            </div>
          </div>
          <div>
            <button className ='rounded bg-pink-900 text-white mt-8 px-3 py-2 w-48' type="submit">
              Search
            </button>
          </div>
        </form>
        <div>
          <h6 className='text-sm font-medium'>Recent Searches</h6>
            <div className='flex gap-1'>
              {queries?.map(({query})=>{
                console.log(query)
                return <small className='font-medium capitalize rounded-full bg-pink-700 text-white px-2'>{query}</small>

              })}
            </div>
        </div>
      </div>
      <div className='mt-10 space-y-4'> 
      {results?.value?.search?.map((movie)=>
        <Link key={movie.imdbID} to={`/movie/${movie.imdbID}`} className='flex gap-6 bg-zinc-100 rounded hover:bg-zinc-200'>       
          <img src={movie.poster ?? ''} height={120} width={120} alt={movie.title}/>
          <div className='space-y-2'>
          <p className='font-medium capitalize'>{movie.title}</p>
          <p>{movie.year}</p>
          <p className='font-medium capitalize rounded-full bg-pink-700 text-white px-2 w-16'>{movie.type}</p>
          </div>
          
        </Link>
      )}
      </div>
     
</div>
    );
  }
  
  export default MovieDirectory;
  