import { useEffect,useState } from 'react'
import {useParams } from 'react-router-dom'

const MovieDetails = () => {
    const {id}=useParams()
    const [ movieDetails, setMovieDetails] = useState(null)
    const [ ratings, setRatingsDetails] = useState(null)
      useEffect(() => {
        fetch(`${process.env.REACT_APP_BASE_URL}/api/Movies/${id}`)
            .then(response => {
            return response.json()
            })
            .then(data => {
            setMovieDetails(data.value)
            })
      }, [id]);
      return (
        <div>
            <h1 className='flex flex-auto justify-center text-2xl bg-zinc-300 text-black'>Extended Movie Info</h1>
            {movieDetails ? (<div className='flex border-gray-300 border rounded my-4 flex-col p-4 w-2/5 mx-auto'>
                <img src={movieDetails.poster ?? ''} height={120} width={120} alt={movieDetails.title}/>
                <div className='space-y-2 '>
                <p className='font-medium capitalize bg-pink-200'>{movieDetails.title}</p>
                <p className='bg-zinc-100 rounded hover:bg-zinc-200'>Year: {movieDetails.year}</p>
                <p className='bg-zinc-100 rounded hover:bg-zinc-200'>Rated: {movieDetails.rated}</p>
                <p className='bg-zinc-100 rounded hover:bg-zinc-200'>Released: {movieDetails.released}</p>
                <p className='bg-zinc-100 rounded hover:bg-zinc-200'> Runtime:{movieDetails.runtime}</p>
                <p className='bg-zinc-100 rounded hover:bg-zinc-200'> Genre:{movieDetails.genre}</p>
                <p className='bg-zinc-100 rounded hover:bg-zinc-200'>Director: {movieDetails.director}</p>
                <p className='bg-zinc-100 rounded hover:bg-zinc-200'>Writer: {movieDetails.writer}</p>
                <p className='bg-zinc-100 rounded hover:bg-zinc-200'>Actors: {movieDetails.actors}</p>
                <p className='bg-zinc-100 rounded hover:bg-zinc-200'>Plot: {movieDetails.plot}</p>
                <p className='bg-zinc-100 rounded hover:bg-zinc-200'>Language: {movieDetails.language}</p>
                <p className='bg-zinc-100 rounded hover:bg-zinc-200'>Country: {movieDetails.country}</p>
                <p className='bg-zinc-100 rounded hover:bg-zinc-200'>MetaScore: {movieDetails.metascore}</p>
                {/* <p className='bg-zinc-100 rounded hover:bg-zinc-200'>imdbRating: {movieDetails.imdbRating}</p>
                <p className='bg-zinc-100 rounded hover:bg-zinc-200'>imdbVotes: {movieDetails.imdbVotes}</p>
                <p className='bg-zinc-100 rounded hover:bg-zinc-200'>imbdbID: {movieDetails.imbdbID}</p>
                <p className='bg-zinc-100 rounded hover:bg-zinc-200'>Type: {movieDetails.type}</p>
                <p className='bg-zinc-100 rounded hover:bg-zinc-200'>DVD: {movieDetails.dvd}</p>
                <p className='bg-zinc-100 rounded hover:bg-zinc-200'>BoxOffice: {movieDetails.boxoffice}</p>
                <p className='bg-zinc-100 rounded hover:bg-zinc-200'>Production: {movieDetails.production}</p>
                <p className='bg-zinc-100 rounded hover:bg-zinc-200'>Website: {movieDetails.website}</p> */}
                <p className='bg-zinc-100 rounded hover:bg-zinc-200'>Response: {movieDetails.response}</p>
                <h2 className='bg-pink-300'>Ratings</h2>
                {movieDetails.ratings.map(ratings => (
                    <span className='flex flex-col bg-zinc-100 rounded hover:bg-zinc-200'>
                    <p>Source: {ratings.source}, Value: {ratings.value}</p>
                    </span>
                
                    
                    
                ))}
       
       
       
               


                
               
                

                <p className='font-medium capitalize rounded-full bg-pink-700 text-white px-2 w-16'>{movieDetails.type}</p>
                </div>
                
            </div>) : <p>Loading...</p>}
        </div> 
        )

    }
    export default MovieDetails

      

     
      
   
    // <div className='mt-10 space-y-4'> 
    // {results?.value?.search?.map((movie)=>
    //   <Link key={movie.imdbID} to={`/movie/${movie.imdbID}`} className='flex gap-6 bg-zinc-100 rounded hover:bg-zinc-200'>       
    //     <img src={movie.poster ?? ''} height={120} width={120} alt={movie.title}/>
    //     <div className='space-y-2'>
    //     <p className='font-medium capitalize'>{movie.title}</p>
    //     <p>{movie.year}</p>
    //     <p className='font-medium capitalize rounded-full bg-pink-700 text-white px-2 w-16'>{movie.type}</p>
    //     </div>
        
    //   </Link>
    // )}
    // </div>
      
      
      
      //https://localhost:44326/api/Movies/tt0120338