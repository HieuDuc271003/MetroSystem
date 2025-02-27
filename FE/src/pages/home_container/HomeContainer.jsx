import React from 'react'
import Hero from '../hero/Hero'
import Search from '../search/Search'
import Category from '../category/Category'

export default function HomeContainer() {
  return (
    <>
    {/* Hero section and other home related content */}
    <Hero/>
    <Search/>
    <Category/>
    </>
  )
}
